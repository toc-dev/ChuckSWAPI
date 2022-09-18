using ChuckSWAPI.Services.Implementations;
using ChuckSWAPI.Services.Interfaces;

namespace ChuckSWAPI.Services.Extensions
{
    public static class ServiceRegistry
    {
        public static IServiceCollection RegisterChuckSWapiServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IChuckNorris, ChuckNorris>();
            services.AddScoped<ISwapi, Swapi>();

            return services;
        }
    }
}
