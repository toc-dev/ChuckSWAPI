using ChuckSWWeb.Models.ChuckNorris;

namespace ChuckSWWeb.Services.Interfaces
{
    public interface IChuckService
    {
        Task<JokeCategories> GetAll();
        Task<RandomJoke> GetRandomJoke();
    }
}
