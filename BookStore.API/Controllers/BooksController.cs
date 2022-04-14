using BookRepository.Data;
using BookRepository.Repository;
using Microsoft.AspNetCore.Http;
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
    }
}
