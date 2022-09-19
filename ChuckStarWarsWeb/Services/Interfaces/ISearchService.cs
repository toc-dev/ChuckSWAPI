using ChuckSWShared.Dtos;
using ChuckSWShared.Dtos.ChuckNorrisDtos;
using ChuckSWShared.Dtos.StarWarsDto;

namespace ChuckSWWeb.Services.Interfaces
{
    public interface ISearchService
    {
        Task<SearchResultsDto> GetSearchResult(string searchTerm);
    }
}
