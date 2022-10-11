using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Vettvangur.Search.Services;

namespace Vettvangur.Search
{
    class Startup : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddScoped<SearchService>();
            builder.Components().Insert<IndexComponent>();
        }
    }
}
