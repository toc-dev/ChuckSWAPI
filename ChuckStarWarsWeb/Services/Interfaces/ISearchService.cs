using ChuckSWShared.Dtos.ChuckNorrisDtos;
using ChuckSWShared.Dtos.StarWarsDto;

namespace ChuckSWWeb.Services.Interfaces
{
    public interface ISearchService
    {
        Task<object> GetSearchResult(string searchTerm);
    }
}
