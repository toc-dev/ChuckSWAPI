using AutoMapper;
using ChuckSWAPI.Models;
using ChuckSWAPI.Models.ChuckNorris;
using ChuckSWAPI.Services.Interfaces;
using ChuckSWShared.Dtos.ChuckNorrisDtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChuckSWAPI.Services.Implementations
{
    public class ChuckNorris : IChuckNorris
    {
        private readonly string baseUrl;


        private static readonly HttpClient _httpClient = new HttpClient();

        public ChuckNorris(IConfiguration configuration)
        {
            baseUrl = configuration.GetValue<string>("ChuckNorrisConfig:BaseUrl");
        }

        public async Task<JokeCategories> GetJokeCategories()
        {
            var url = baseUrl + "categories";

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            var contents = JsonConvert.DeserializeObject(content).ToString();

            List<string> jokesCategories = JsonConvert.DeserializeObject<List<string>>(contents);

            JokeCategories jokeCategories = new JokeCategories()
            {
                Category = jokesCategories
            };
            return jokeCategories;
        }

        public async Task<RandomJoke> GetRandomJoke()
        {
            var randomJokeUrl = baseUrl + "random";
            HttpResponseMessage response = await _httpClient.GetAsync(randomJokeUrl);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            var contents = JsonConvert.DeserializeObject(content).ToString();

            RandomJoke randomJoke = JsonConvert.DeserializeObject<RandomJoke>(contents);


            return randomJoke;
        }

        public async Task<JokeSearchResultDto> SearchJoke(string searchTerm)
        {
            
            var searchUrl = baseUrl + "search?query=" + searchTerm;

            HttpResponseMessage response = await _httpClient.GetAsync(searchUrl);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            JokeSearchResult searchResults = JsonConvert.DeserializeObject<JokeSearchResult>(content);

            JokeSearchResultDto jokeSearchResultDto = new()
            {
                Total = searchResults.Total,
                Results = searchResults.Result.Select(s => new SearchResult() { Categories = s.Categories, Url = s.Url, Value = s.Value }).ToArray()

            };

            return jokeSearchResultDto;
        }
    }
}
