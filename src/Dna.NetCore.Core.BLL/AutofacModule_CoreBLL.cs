using Autofac;
using System.Reflection;

namespace Dna.NetCore.Core.BLL
{
    public class AutofacModule_CoreBLL : Autofac.Module
    {
        #region ctor

        public AutofacModule_CoreBLL()
        {
        }

        #endregion

        #region Methods

        protected override void Load(ContainerBuilder builder)
		{
            RegisterComponents(builder);
        }

        private void RegisterComponents(ContainerBuilder builder)
        {
            var assembly = Assembly.Load(new AssemblyName("Dna.NetCore.Core.BLL"));

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Queries"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("CrudServices"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("HelperServices"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }

        #endregion
    }
}
