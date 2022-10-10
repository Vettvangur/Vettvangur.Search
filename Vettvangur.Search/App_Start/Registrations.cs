using Umbraco.Core;
using Umbraco.Core.Composing;
using Vettvangur.Search.Services;

namespace Vettvangur.Search.App_Start
{
    /// <summary>
    /// Registers the type mappings with Umbraco IoC.
    /// </summary>
    static class Registrations
    {
        /// <summary>Registers the type mappings with Umbraco IoC.</summary>
        public static void Register(Composition composition)
        {
            composition.Register<SearchService>();
        }
    }
}
