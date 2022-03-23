using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.Data.Models;
using My_Books.Data.Services;
using My_Books.Data.ViewModel;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        AuthorsService _authorsService;
        private readonly ILogger<AuthorsController> _logger;
        public AuthorsController(AuthorsService authorsService, ILogger<AuthorsController> logger)
        {
            _authorsService = authorsService;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }
        [HttpGet]
        public IActionResult getAuthors()
        {
            _logger.LogInformation("Hi I am here ***********************************");
            return Ok(_authorsService.GetAuthors());
        }
        [HttpGet("getAuthorById/{id}")]
        public IActionResult getAuthorById(int id)
        {
            return Ok(_authorsService.GetAuthorByID(id));
        }

        [HttpDelete("deleteAuthorsById/{id}")]
        public IActionResult deleteAuthorsById(int id)
        {
            _authorsService.deleteAuthorById(id);
            return Ok();
        }
        [HttpPut("updateAuthorsById/{id}")]
        public IActionResult updateAuthorsById(int id, [FromBody] AuthorVM author)
        {
            _authorsService.updateAuthorById(id, author);
            return Ok();
        }
    }
}
