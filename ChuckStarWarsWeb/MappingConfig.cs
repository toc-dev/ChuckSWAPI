using AutoMapper;
using ChuckSWWeb.Models.StarWars;

namespace ChuckSWWeb
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Planet, Planet>().ReverseMap();
        }
    }
}
