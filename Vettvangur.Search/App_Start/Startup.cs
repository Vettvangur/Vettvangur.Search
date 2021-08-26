using Examine;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Mapping;
using Umbraco.Core.Persistence;

namespace Vettvangur.Search.App_Start
{
    class StartupComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components()
                .Append<Startup>();
        }
    }
    class Startup : IComponent
    {
        protected readonly ILogger Logger;
        protected readonly IFactory Factory;
        protected readonly IUmbracoDatabaseFactory DatabaseFactory;
        private readonly IExamineManager _examineManager;
        public Startup(
            ILogger logger,
            IFactory factory,
            IUmbracoDatabaseFactory databaseFactory,
            IExamineManager examineManager

        )
        {
            Logger = logger;
            Factory = factory;
            DatabaseFactory = databaseFactory; 
            _examineManager = examineManager;
        }

        /// <summary>
        /// Umbraco startup lifecycle method
        /// </summary>
        public void Initialize()
        {

        }

        public void Terminate()
        {
        }

    }
}
