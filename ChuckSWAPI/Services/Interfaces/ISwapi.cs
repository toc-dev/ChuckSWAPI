using ChuckSWAPI.Models;
using ChuckSWAPI.Models.StarWars;
using ChuckSWShared.Dtos.StarWarsDto;

namespace ChuckSWAPI.Services.Interfaces
{
    public interface ISwapi
    {
        Task<PeopleDto> GetSwapiPeople(int pageNumber=1);
        Task<PeopleDto> SearchSwapiPeople(string searchTerm);
    }
}
