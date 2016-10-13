using Autofac;

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
        }

        #endregion
    }
}