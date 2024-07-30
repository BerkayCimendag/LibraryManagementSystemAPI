using LibraryManagementSystemAPI.AbstractServices;
using LibraryManagementSystemAPI.Data;
using LibraryManagementSystemAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.ConcreteServices
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Book> AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;                            
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                book.IsDeleted = true;
                 _context.Books.Update(book);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var allBooks = await _context.Books.ToListAsync();

            allBooks = allBooks.Where(x => x.IsDeleted == false).ToList();
            
            return  allBooks;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return book;
        }

        public async Task<Book> UpdateBookAsync(int id,Book bookToUpdate)
        {
            var book = await _context.Books.FindAsync(id);

            //book.Id = bookToUpdate.Id;
            //book.Author = bookToUpdate.Author;
            //book.RentedDay = bookToUpdate.RentedDay;
            //book.MaxRentDay = bookToUpdate.MaxRentDay;
            //book.IsRented = bookToUpdate.IsRented;
            //book.UserId = bookToUpdate.UserId;
            //book.DailyPenaltyFee = bookToUpdate.DailyPenaltyFee;
            //book.Title = bookToUpdate.Title;
            //book.User = bookToUpdate.User;
            //book.ReleaseDate = bookToUpdate.ReleaseDate;
            //book.PageCount = bookToUpdate.PageCount;
            //book.IsDeleted = bookToUpdate.IsDeleted;

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
             return bookToUpdate;
        }
    }
}
