using ChuckSWAPI.Models;
using ChuckSWAPI.Models.ChuckNorris;

namespace ChuckSWAPI.Services.Interfaces
{
    public interface IChuckNorris
    {
        Task<JokeCategories> GetJokeCategories();
        Task<RandomJoke> GetRandomJoke();
    }
}
