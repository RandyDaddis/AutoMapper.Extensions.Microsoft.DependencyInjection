using AspNetCore.NetCore.WebApp.Initializers;
using Autofac;
using Dna.NetCore.Core.CommandProcessing;
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

        protected override void Load(ContainerBuilder builder)  // DEVNOTE: Load() is executed via Startup.DI_AutofacContainer_Configure() | _container = _builder.Build();
        {
            RegisterComponents(builder);
        }

        private static void RegisterComponents(ContainerBuilder builder)
        {
            // TODO

            //ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            //builder.Register(ctx => applicationDbContext)
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<DatabaseFactory<ApplicationDbContext>>()
            //    .As<IDatabaseFactory<ApplicationDbContext>>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<Logger>().As<ILogger>()
            //    .InstancePerLifetimeScope();

            builder.RegisterType<SeedData>();
            //builder.RegisterType<SeedData>().As<ISeedData>()
            //    .InstancePerLifetimeScope();
            //builder.Register(t => new SeedData())
            //    .InstancePerLifetimeScope();
            //builder.Register(() => new SeedData())
            //    .InstancePerLifetimeScope();
        }

        #endregion
    }
}