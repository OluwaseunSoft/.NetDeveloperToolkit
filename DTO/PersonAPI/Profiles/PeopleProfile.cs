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
            CreateMap<Person, PersonDto>();
        }
    }
}