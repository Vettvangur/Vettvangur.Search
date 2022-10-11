using Vettvangur.Search.Services;

namespace Vettvangur.Search
{
    static class ApplicationBuilderExtensions
    {
        public static IServiceCollection AddVettvangurSearch(this IServiceCollection services)
        {
            services.AddScoped<SearchService>();

            return services;
        }
    }
}
