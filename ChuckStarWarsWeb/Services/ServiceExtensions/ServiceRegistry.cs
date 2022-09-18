using ChuckSWWeb.Services.Implementations;
using ChuckSWWeb.Services.Interfaces;

namespace ChuckSWWeb.Services.ServiceExtensions
{
    public static class ServiceRegistry
    {
        public static IServiceCollection RegisterChuckSWWebServices(this IServiceCollection services)
        {
            services.AddHttpClient<IChuckService, ChuckService>();
            services.AddScoped<IChuckService, ChuckService>();
            services.AddScoped<IStarWarsService, StarWarsService>();
            //services.AddScoped<ISwapi, Swapi>();

            return services;
        }
    }
}
