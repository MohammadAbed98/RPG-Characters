using ASP.Dtos.Character;
using ASP.Models;
using AutoMapper;

namespace ASP
{
    public class AutoMapperProfile : Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}
