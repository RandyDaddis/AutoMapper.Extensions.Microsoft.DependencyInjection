using Autofac;
using System.Linq;
using System.Reflection;

namespace Dna.NetCore.Core.DAL.AutoMapper
{
    public class AutofacModule_CoreDALAutoMapper : Autofac.Module
    {
        #region ctor

        public AutofacModule_CoreDALAutoMapper()
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
            var assembly = Assembly.Load(new AssemblyName("Dna.NetCore.Core.DAL.AutoMapper"));

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

        }

        #endregion
    }
}
