using Crayons.Api.Domain.Models;
using Crayons.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crayons.Api.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok( _bookService.GetAll() );
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {   
            return Ok( _bookService.GetById(id) );
        }

        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            _bookService.Add(book);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody]Book book)
        {
            _bookService.Update(book);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return Ok();
        }
    }
}