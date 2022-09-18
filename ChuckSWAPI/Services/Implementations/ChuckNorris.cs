using ChuckSWAPI.Models;
using ChuckSWAPI.Models.ChuckNorris;
using ChuckSWAPI.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChuckSWAPI.Services.Implementations
{
    public class ChuckNorris : IChuckNorris
    {
        //private const string baseUrl;
        private const string baseAddress = "https://api.chucknorris.io/jokes/categories";
        private const string randomJokeAddress = "https://api.chucknorris.io/jokes/random";


        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<JokeCategories> GetJokeCategories()
        {
            
            HttpResponseMessage response = await _httpClient.GetAsync(baseAddress);
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
            HttpResponseMessage response = await _httpClient.GetAsync(randomJokeAddress);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            var contents = JsonConvert.DeserializeObject(content).ToString();

            RandomJoke randomJoke = JsonConvert.DeserializeObject<RandomJoke>(contents);

           
            return randomJoke;
        }
    }
}
