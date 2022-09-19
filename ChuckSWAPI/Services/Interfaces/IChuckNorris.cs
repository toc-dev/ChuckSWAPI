using ChuckSWAPI.Models;
using ChuckSWAPI.Models.ChuckNorris;
using ChuckSWShared.Dtos.ChuckNorrisDtos;

namespace ChuckSWAPI.Services.Interfaces
{
    public interface IChuckNorris
    {
        Task<JokeCategories> GetJokeCategories();
        Task<RandomJoke> GetRandomJoke();
        Task<JokeSearchResultDto> SearchJoke(string searchTerm);
    }
}
