using ChuckSWWeb.Models;


namespace ChuckSWWeb.Services.Interfaces
{
    public interface IBaseService
    {
        public ApiResponse ResponseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
