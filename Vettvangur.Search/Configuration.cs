using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Vettvangur.Search
{
    public class Configuration
    {
        readonly IConfiguration _configuration;

        public Configuration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static IServiceProvider Resolver { get; internal set; }

        public static Configuration Instance => Resolver.GetService<Configuration>();
    }
}
