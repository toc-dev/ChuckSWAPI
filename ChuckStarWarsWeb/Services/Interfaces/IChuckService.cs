using ChuckSWWeb.Models.ChuckNorris;

namespace ChuckSWWeb.Services.Interfaces
{
    public interface IChuckService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<JokeCategories> GetAll();
        Task<RandomJoke> GetRandomJoke();
    }
}
