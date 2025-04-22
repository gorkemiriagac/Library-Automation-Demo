using AutoMapper;
using Library.DTO.Dtos.BorrowedBookDtos;
using Library.Entity.Entities;

namespace Library.WebAPI.Mapping
{
    public class BorrowedBookMapping:Profile
    {
        public BorrowedBookMapping()
        {
            CreateMap<CreateBorrowedBookDtos, BorrowedBook>().ReverseMap();
            CreateMap<UpdateBorrowedBookDtos, BorrowedBook>().ReverseMap();
            CreateMap<ResultBorrowedBook, BorrowedBook>().ReverseMap();
        }

    }
}
