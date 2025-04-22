using AutoMapper;
using Library.Business.Abstract;
using Library.DTO.Dtos.AuthorDtos;
using Library.DTO.Dtos.BookDtos;
using Library.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IBookService _bookService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _bookService.TGetBookWithAuthorName();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _bookService.TGetById(id);
            return Ok(values);
        }

        [HttpDelete("{id}")]//todo unuttun
        public IActionResult Delete(int id)
        {
            _bookService.TDelete(id);
            return Ok("Book Deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateBookDtos createBookDtos)
        {
            var newValue = _mapper.Map<Book>(createBookDtos);
            _bookService.TCreate(newValue);
            return Ok("New Book Added");
        }
        [HttpPut]
        public IActionResult Update(UpdateBookDtos updateBookDtos)
        {
            var value = _mapper.Map<Book>(updateBookDtos);
            _bookService.TUpdate(value);
            return Ok("Book Updated");
        }

        
        
    }
}
