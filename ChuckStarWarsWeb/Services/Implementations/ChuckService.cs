using ChuckSWUtility;
using ChuckSWWeb.Models;
using ChuckSWWeb.Models.ChuckNorris;
using ChuckSWWeb.Services.Interfaces;
using Newtonsoft.Json;

namespace ChuckSWWeb.Services.Implementations
{
    public class ChuckService : BaseService, IChuckService
    {
        private readonly IHttpClientFactory _clientFactory;
        private static readonly HttpClient _httpClient = new HttpClient();

        private string _chuckUrl;
        public ChuckService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            _chuckUrl = configuration.GetValue<string>("ServiceUrls:ChuckSWAPI");
        }

        public async Task<JokeCategories> GetAll()
        {
            JokeCategories joke = new();
            var url = _chuckUrl + "/chuck/categories";
            var response = _httpClient.GetAsync(url);

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsAsync<JokeCategories>();
                joke = read.Result;
            }


            return joke;
        }

        public async Task<RandomJoke> GetRandomJoke()
        {
            RandomJoke joke = new();
            var url = _chuckUrl + "/chuck/randomJoke";
            var response = _httpClient.GetAsync(url);

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsAsync<RandomJoke>();
                joke = read.Result;
            }


            return joke;
        }


        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = _chuckUrl + "/chuck/categories"
            });

        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = _chuckUrl + "/api/chuck" + id
            }); ;
        }
    }
}
