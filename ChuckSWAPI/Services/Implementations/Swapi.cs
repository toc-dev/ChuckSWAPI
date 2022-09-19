using ChuckSWAPI.Models;
using ChuckSWAPI.Models.StarWars;
using ChuckSWAPI.Services.Interfaces;
using ChuckSWShared.Dtos.StarWarsDto;
using Newtonsoft.Json;

namespace ChuckSWAPI.Services.Implementations
{
    public class Swapi : ISwapi
    {
        private const string baseAddress = "https://swapi.dev/api/people/";
        private static readonly HttpClient _httpClient = new HttpClient();
        public async Task<People> GetSwapiPeople()
        {

            HttpResponseMessage response = await _httpClient.GetAsync(baseAddress);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            People people = JsonConvert.DeserializeObject<People>(content);


            return people;
        }

        public async Task<People> SearchSwapiPeople(string searchTerm)
        {
            var searchUrl = baseAddress + "?search=" + searchTerm;
            HttpResponseMessage response = await _httpClient.GetAsync(searchUrl);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            People people = JsonConvert.DeserializeObject<People>(content);

            PeopleDto peopleDto = new()
            {
                Count = people.Count,
                Results = people.Results.Select(p => new PeopleResult() { Name = p.Name, Url = p.Url }).ToArray()
            };
            return people;
        }
    }
}
