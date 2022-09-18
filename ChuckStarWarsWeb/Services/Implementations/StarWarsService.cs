using ChuckSWWeb.Models.StarWars;
using ChuckSWWeb.Services.Interfaces;

namespace ChuckSWWeb.Services.Implementations
{
    public class StarWarsService : IStarWarsService
    {
        private readonly IHttpClientFactory _clientFactory;
        private static readonly HttpClient _httpClient = new HttpClient();

        private string _starWarsUrl;

        public StarWarsService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _starWarsUrl = configuration.GetValue<string>("ServiceUrls:ChuckSWAPI");
        }
        public async Task<People> GetAll()
        {
            People people = new();
            var url = _starWarsUrl + "/swapi/people";
            var response = await _httpClient.GetAsync(url);

            //var result = response;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsAsync<People>();
                people = read.Result;
            }


            return people;
        }
    }
}
