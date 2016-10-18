using Autofac;
using System.Reflection;

namespace Dna.NetCore.Core.DAL.EFCore
{
    public class AutofacModule_CoreDALEFCore : Autofac.Module
    {
        #region ctor

        public AutofacModule_CoreDALEFCore()
        {
        }

        #endregion

        #region Methods

        protected override void Load(ContainerBuilder builder)
        {
            RegisterComponents(builder);
        }

        private static void RegisterComponents(ContainerBuilder builder)
        {
            var assembly = Assembly.Load(new AssemblyName("Dna.NetCore.Core.DAL.EFCore"));

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .WithParameter("databaseFactory", new DatabaseFactory<CoreEFContext>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<DatabaseFactory<CoreEFContext>>()
                .As<IDatabaseFactory<CoreEFContext>>()
                .InstancePerLifetimeScope();

        }

        #endregion
    }
}
