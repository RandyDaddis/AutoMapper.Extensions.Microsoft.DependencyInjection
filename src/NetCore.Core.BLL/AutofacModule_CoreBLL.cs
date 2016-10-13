using Autofac;
using System.Reflection;

namespace NetCore.Core.BLL
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
            var assembly = Assembly.Load(new AssemblyName("NetCore.Core.BLL"));

            // ConfigurationProviderProxy.cs is no longer necessary. 
            //   - I have refactored type mapping from AutoMapper.IMappingEngine to AutoMapper.AutoMapper
            //   - AutoMapper.AutoMapper is not injected via DI.It is referenced directly in *_mapper.cs
            //builder.RegisterType<ConfigurationProviderProxy>()
            //    .As<IConfigurationProvider>()
            //    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Mapper"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

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
