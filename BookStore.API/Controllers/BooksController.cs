using BookRepository.Data;
using BookRepository.Models;
using BookRepository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
       
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
           _bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books =await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBookById([FromRoute]int bookId)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] BookModel bookModel)
        {
            var bookId = await _bookRepository.AddBookAsync(bookModel);
            return CreatedAtAction(nameof(GetBookById), new { bookId = bookId, controller = "books" },bookId);
        }

        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateBook([FromRoute]int bookId,
        [FromBody] BookModel bookModel)
        {
            await _bookRepository.UpdateBookAsync(bookId, bookModel);
            return Ok();
        }

        [HttpPut("sdbc/{bookId}")]
        public async Task<IActionResult> UpdateBookSingledataBaseCall([FromRoute] int bookId,
       [FromBody] BookModel bookModel)
        {
            await _bookRepository.UpdateBookSingleDataBaseCallAsync(bookId, bookModel);
            return Ok();
        }

        [HttpPatch("{bookId}")]
        public async Task<IActionResult> UpdateBookPatch([FromRoute] int bookId,
       [FromBody] JsonPatchDocument bookModel)
        {
            await _bookRepository.UpdateBookPatchAsync(bookId, bookModel);
            return Ok();
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int bookId)
        {
            await _bookRepository.DeleteBookAsync(bookId);
            return Ok();
        }


    }
}
