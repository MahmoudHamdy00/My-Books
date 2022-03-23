using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.Data.Models;
using My_Books.Data.Services;
using My_Books.Data.ViewModel;
using My_Books.Exceptions;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        PublishersService _publishersService;
        public PublisherController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }
        [HttpPost]

        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                _publishersService.AddPublisher(publisher);
                return Ok();
            }
            catch (InvalidNameException ex)
            {
                return BadRequest(ex.Message + ex.name);
            }
        }
        [HttpGet]
        public List<Publisher> getPiblishers(int pageIndex)
        {
            return _publishersService.GetPublishers(pageIndex);
            //return Ok(_publishersService.GetPublishers());
        }
        [HttpGet("getPublisherById/{id}")]
        public IActionResult getPublisherById(int id)
        {
            return Ok(_publishersService.GetPublisherByID(id));
        }

        [HttpDelete("deletePublishersById/{id}")]
        public IActionResult deletepublishersById(int id)
        {
            _publishersService.deletePublisherById(id);
            return Ok();
        }
        [HttpPut("updatepublishersById/{id}")]
        public IActionResult updatepublishersById(int id, [FromBody] PublisherVM publisher)
        {
            _publishersService.updatePublisherById(id, publisher);
            return Ok();
        }
    }
}
