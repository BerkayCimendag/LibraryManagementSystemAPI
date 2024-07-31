using LibraryManagementSystemAPI.Entities;

namespace LibraryManagementSystemAPI.AbstractServices
{
    public interface IUserService
    {
        Task SignIn(User user);

        Task<List<UsersBook>> GetMyRentedBooks(int userId);

        Task ReturnRentedBook(int userId,int bookId);
    }
}
