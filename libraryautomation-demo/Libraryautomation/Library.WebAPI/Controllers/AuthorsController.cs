using AutoMapper;
using Library.Business.Abstract;
using Library.DTO.Dtos.AuthorDtos;
using Library.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController(IGenericService<Author> _authorService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values=_authorService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values= _authorService.TGetById(id);
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authorService.TDelete(id);
            return Ok("Atuhor Deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateAuthorDto createAuthorDto)
        {
            var newValue=_mapper.Map<Author>(createAuthorDto);
            _authorService.TCreate(newValue);
            return Ok("New Author Added");
        }
        [HttpPut]
        public IActionResult Update(UpdateAuthorDto updateAuthorDto)
        {
            var value=_mapper.Map<Author>(updateAuthorDto);
            _authorService.TUpdate(value);
            return Ok("Author Updated");
        }

    }
}
