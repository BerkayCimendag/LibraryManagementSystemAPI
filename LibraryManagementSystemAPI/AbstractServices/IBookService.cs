using LibraryManagementSystemAPI.Entities;

namespace LibraryManagementSystemAPI.AbstractServices
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(int id,Book bookToUpdate);
        Task DeleteBookAsync(int id);
    }
}
