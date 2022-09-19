using ChuckSWAPI.Models.ChuckNorris;
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
        public async Task<object> GetSearchResult(string searchTerm)
        {
            JokeSearchResultDto jokeSearch = await GetJokeSearchResults();
            PeopleDto peopleSearch = await GetPeopleResults();

            if (jokeSearch.Total != 0)
            {
                return jokeSearch;
            }
            if(peopleSearch.Count != 0)
            {
                return peopleSearch;
            }
            return(jokeSearch, peopleSearch);

        }

        private async Task<JokeSearchResultDto> GetJokeSearchResults()
        {
            JokeSearchResultDto jokeSearchResult = new();
            var chuckUrl = _chuckSWApiUrl + "/search/SearchChuck";
            var response = _httpClient.GetAsync(chuckUrl);

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsAsync<JokeSearchResultDto>();
                jokeSearchResult = read.Result;
            }
            return jokeSearchResult;
        }
        
        private async Task<PeopleDto> GetPeopleResults()
        {
            PeopleDto peopleSearchResult = new();
            var swapiUrl = _chuckSWApiUrl + "/search/SearchSWApi";
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
