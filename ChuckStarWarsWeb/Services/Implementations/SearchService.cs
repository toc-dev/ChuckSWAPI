using ChuckSWAPI.Models.ChuckNorris;
using ChuckSWShared.Dtos;
using ChuckSWShared.Dtos.ChuckNorrisDtos;
using ChuckSWShared.Dtos.StarWarsDto;
using ChuckSWWeb.Services.Interfaces;

namespace ChuckSWWeb.Services.Implementations
{
    public class SearchService : ISearchService
    {
        private readonly IHttpClientFactory _clientFactory;
        private static readonly HttpClient _httpClient = new HttpClient();

        private string _chuckSWApiUrl;
        public SearchService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _chuckSWApiUrl = configuration.GetValue<string>("ServiceUrls:ChuckSWAPI");
        }
        public async Task<SearchResultsDto> GetSearchResult(string searchTerm)
        {
            SearchResultsDto searchResult = new();
            JokeSearchResultDto jokeSearch = await GetJokeSearchResults(searchTerm);
            PeopleDto peopleSearch = await GetPeopleResults(searchTerm);

            if (jokeSearch.Total != 0)
            {
                searchResult.Total = jokeSearch.Total;
                searchResult.Results = jokeSearch.Results.Select(s => new SearchResults() { Categories = s.Categories, Url = s.Url, Value = s.Value, SearchType = "Chuck Norris Jokes" }).ToArray();
            }
            if(peopleSearch.Count != 0)
            {
                searchResult.Total = peopleSearch.Count;
                searchResult.Results = peopleSearch.Results.Select(s => new SearchResults() { Url = s.Url, Value = s.Name, SearchType = "Star Wars People" }).ToArray();
            }
            return searchResult;

        }

        private async Task<JokeSearchResultDto> GetJokeSearchResults(string searchTerm)
        {
            JokeSearchResultDto jokeSearchResult = new();
            var chuckUrl = _chuckSWApiUrl + $"/search/SearchChuck/{searchTerm}";
            var response = _httpClient.GetAsync(chuckUrl);

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsAsync<JokeSearchResultDto>();
                jokeSearchResult = read.Result;
            }
            return jokeSearchResult;
        }
        
        private async Task<PeopleDto> GetPeopleResults(string searchTerm)
        {
            PeopleDto peopleSearchResult = new();
            var swapiUrl = _chuckSWApiUrl + $"/search/SearchSWApi/{searchTerm}";
            var response = _httpClient.GetAsync(swapiUrl);

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsAsync<PeopleDto>();
                peopleSearchResult = read.Result;
            }
            return peopleSearchResult;
        }
    }
}
