using ChuckSWUtility;
using ChuckSWWeb.Models;
using ChuckSWWeb.Models.ChuckNorris;
using ChuckSWWeb.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace ChuckSWWeb.Services.Implementations
{
    public class BaseService : IBaseService
    {
        public ApiResponse ResponseModel { get; set; }
        public IHttpClientFactory _httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            this.ResponseModel = new();
            _httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("ChuckSWApi");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                switch (apiRequest.ApiType)
                {
                    case StaticDetails.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    
                    case StaticDetails.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    
                    case StaticDetails.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;

                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponse = null;

                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsAsync<T>();
                //var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return apiContent;
            }
            catch(Exception e)
            {
                var responseDto = new ApiResponse
                {
                    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(responseDto);
                var APIResponse = JsonConvert.DeserializeObject<T>(res);
                return APIResponse;
            }
        }
    }
}
