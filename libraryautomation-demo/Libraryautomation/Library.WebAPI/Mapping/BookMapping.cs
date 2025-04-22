using AutoMapper;
using Library.DTO.Dtos.BookDtos;
using Library.Entity.Entities;

namespace Library.WebAPI.Mapping
{
    public class BookMapping:Profile
    {
        public BookMapping()
        {
            CreateMap<CreateBookDtos, Book>().ReverseMap();
            CreateMap<UpdateBookDtos, Book>().ReverseMap();
            CreateMap<ResultBookDtos, Book>().ReverseMap();
        }
    }
}
