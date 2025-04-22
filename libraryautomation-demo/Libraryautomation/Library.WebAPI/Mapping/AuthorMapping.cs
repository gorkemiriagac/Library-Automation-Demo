using AutoMapper;
using Library.DTO.Dtos.AuthorDtos;
using Library.Entity.Entities;

namespace Library.WebAPI.Mapping
{
    public class AuthorMapping: Profile
    {
        public AuthorMapping()
        {
            CreateMap<CreateAuthorDto, Author>().ReverseMap();
            CreateMap<UpdateAuthorDto, Author>().ReverseMap();
            CreateMap<ResultAuthorDto, Author>().ReverseMap();
        }

    }
}
