using ChuckSWAPI.Models;
using ChuckSWAPI.Models.StarWars;

namespace ChuckSWAPI.Services.Interfaces
{
    public interface ISwapi
    {
        Task<People> GetSwapiPeople();
    }
}
