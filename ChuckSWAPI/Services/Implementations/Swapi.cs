using ChuckSWAPI.Models.StarWars;
using ChuckSWAPI.Services.Interfaces;
using ChuckSWShared.Dtos.StarWarsDto;
using Newtonsoft.Json;

namespace ChuckSWAPI.Services.Implementations
{
    public class Swapi : ISwapi
    {
        private readonly string baseUrl;
        private static readonly HttpClient _httpClient = new HttpClient();

        public Swapi(IConfiguration configuration)
        {
            baseUrl = configuration.GetValue<string>("StarWarsPeopleConfig:BaseUrl");
        }
        public async Task<PeopleDto> GetSwapiPeople(int pageNumber=1)
        {
            //string a = "https://swapi.dev/api/people/?page=3" + pageNumber;
            string peopleUrl = baseUrl + "?page=" + pageNumber;

            HttpResponseMessage response = await _httpClient.GetAsync(peopleUrl);
            if (!response.IsSuccessStatusCode)
            {
                response = await _httpClient.GetAsync(baseUrl);
            }
            string content = await response.Content.ReadAsStringAsync();

            People people = JsonConvert.DeserializeObject<People>(content);


            PeopleDto peopleDto = new()
            {
                Count = people.Count,
                Results = people.Results.Select(p => new PeopleResult() { Name = p.Name, Url = p.Url }).ToArray()
            };
            return peopleDto;
        }

        public async Task<PeopleDto> SearchSwapiPeople(string searchTerm)
        {
            var searchUrl = baseUrl + "?search=" + searchTerm;
            HttpResponseMessage response = await _httpClient.GetAsync(searchUrl);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            People people = JsonConvert.DeserializeObject<People>(content);

            PeopleDto peopleDto = new()
            {
                Count = people.Count,
                Results = people.Results.Select(p => new PeopleResult() { Name = p.Name, Url = p.Url }).ToArray()
            };
            return peopleDto;
        }
    }
}
