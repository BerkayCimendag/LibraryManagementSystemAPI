using LibraryManagementSystemAPI.AbstractServices;
using LibraryManagementSystemAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("getAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpPost("addBook")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _bookService.AddBookAsync(book);

            return Ok(book);
        }

        [HttpGet("getByIdBook")]
        public async Task<IActionResult> GetByIdBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            return Ok(book);
        }

        [HttpDelete("deleteBook")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);

            return Ok();
        }

        [HttpPut("updateBook")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            await _bookService.UpdateBookAsync(id, book);

            return Ok();
        }


        [HttpPost("rentBook")]
        public async Task<IActionResult> RentBook(int bookId, int userId)
        {
            await _bookService.RentBook(bookId, userId);

            return Ok();
        }
    }
}
