using AspNetCore.NetCore.WebApp.Data;
using AspNetCore.NetCore.WebApp.Initializers;
using Autofac;
using Dna.NetCore.Core;
using Dna.NetCore.Core.CommandProcessing;
using Dna.NetCore.Core.DAL.EFCore;
using Dna.NetCore.Core.Initializers;

namespace AspNetCore.NetCore.WebApp
{
    public class AutofacModule_WebApp : Autofac.Module
    {
        #region ctor

        public AutofacModule_WebApp()
        {
        }

        #endregion

        #region methods

        protected override void Load(ContainerBuilder builder)  // DEVNOTE: Load() is executed via Startup.ConfigureAutofacContainer() | _container = builder.Build();
        {
            RegisterComponents(builder);
        }

        private static void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterType<SeedData>();
        }

        #endregion
    }
}