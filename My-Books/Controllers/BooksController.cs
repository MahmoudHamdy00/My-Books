using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.Data.Services;
using My_Books.Data.ViewModel;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class BooksController : ControllerBase
    {
        BooksService _bookService;
        public BooksController(BooksService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _bookService.AddBook(book);
            return Ok();
        }
        [HttpGet]
        public IActionResult getBooks()
        {
            return Ok(_bookService.GetBooks());
        }
        [HttpGet("getBookById/{id}")]
        public IActionResult getBookById(int id)
        {
            return Ok(_bookService.GetBookByID(id));
        }

        [HttpDelete("deleteBookById/{id}")]
        public IActionResult deleteBookById(int id)
        {
            _bookService.deleteBookById(id);
            return Ok();
        }
        [HttpPut("updateBookById/{id}")]
        public IActionResult updateBookById(int id,[FromBody]BookVM book)
        {
            _bookService.updateBookById(id,book);
            return Ok();
        }
    }
}
