using AutoMapper;
using Library.Business.Abstract;
using Library.DTO.Dtos.BorrowedBookDtos;
using Library.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedBooksController(IBorrowedService _borrowedService, IMapper _mapper) : ControllerBase
    {
        //get , getbyıd, delete, create ,update

        [HttpGet]
        public IActionResult Get()
        {
            var values = _borrowedService.TGetBookName();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _borrowedService.TGetById(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _borrowedService.TDelete(id);
            return Ok("BorrowedBook Deleted");
        }
        [HttpPost]
        public IActionResult Create(CreateBorrowedBookDtos createBorrowedBookDtos)
        {
            var newValue=_mapper.Map<BorrowedBook>(createBorrowedBookDtos);
            _borrowedService.TUpdate(newValue);
            return Ok("New BorrowedBook Added");
        }

        [HttpPut]
        public IActionResult Update(UpdateBorrowedBookDtos updateBorrowedBookDtos)
        {
            var values = _mapper.Map<BorrowedBook>(updateBorrowedBookDtos);
            _borrowedService.TUpdate(values);
            return Ok("BorrowedBook Updated");
        }


    }
}
