using LibraryManagementSystemAPI.AbstractServices;
using LibraryManagementSystemAPI.Data;
using LibraryManagementSystemAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.ConcreteServices
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UsersBook>> GetMyRentedBooks(int userId)
        {
           var userBooks = await  _context.UsersBooks.Where(x => x.UserId == userId && !x.IsReturned).Include(x=>x.Book).ToListAsync();

            foreach (var item in userBooks)
            {
                var wholeRentedTime = (DateTime.Now - item.RentedDay).Days;

                if (item.Book.MaxRentDay < wholeRentedTime)
                {
                    item.TotalPenaltyFee = (int)(item.Book.DailyPenaltyFee * (wholeRentedTime - item.Book.MaxRentDay));

                     _context.UsersBooks.Update(item);
                    await _context.SaveChangesAsync();
                }
            }

            return userBooks;
        }

        public async Task ReturnRentedBook(int userId, int bookId)
        {
            var bookToReturn = await _context.UsersBooks.FirstOrDefaultAsync(x => x.UserId == userId && x.BookId == bookId);

            bookToReturn.IsReturned = true;
            bookToReturn.TotalPenaltyFee = 0;
             _context.UsersBooks.Update(bookToReturn);
            await _context.SaveChangesAsync();
        }

        public async Task SignIn(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
