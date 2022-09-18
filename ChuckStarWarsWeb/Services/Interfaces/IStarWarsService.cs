using ChuckSWWeb.Models.StarWars;

namespace ChuckSWWeb.Services.Interfaces
{
    public interface IStarWarsService
    {
        Task<People> GetAll();
    }
}
