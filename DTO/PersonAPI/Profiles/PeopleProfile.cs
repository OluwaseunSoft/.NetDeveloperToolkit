using AutoMapper;
using PersonAPI.Dtos;
using PersonAPI.Models;

namespace PersonAPI.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            //Mapper profile Source -> Destination
            CreateMap<Person, PersonReadDto>()
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.OlderBy));

            CreateMap<PersonCreateDto, Person>()
            .ForMember(dest => dest.FullName, opt => 
            opt.MapFrom(src => src.FirstName + ' ' + src.LastName));

            CreateMap<PersonUpdateDto, Person>()
            .ForMember(dest => dest.FullName, opt => 
            opt.MapFrom(src => src.FirstName + ' ' + src.LastName));

        }
    }
}