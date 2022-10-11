using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Vettvangur.Search
{
    public class IndexComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Components().Insert<IndexComponent>();
        }
    }
}
