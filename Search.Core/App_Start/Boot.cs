using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Composing;

namespace Search.Core.App_Start
{
    /// <summary>
    /// Hooks into application boot, this is done to ensure all registrations have been made to
    /// the IoC container before Hangfire starts up and starts any jobs
    /// </summary>
    class BootComposer : IComposer
    {
        /// <summary>
        /// Umbraco lifecycle method
        /// </summary>
        public void Compose(Composition composition)
        {
            Registrations.Register(composition);
        }
    }
}
