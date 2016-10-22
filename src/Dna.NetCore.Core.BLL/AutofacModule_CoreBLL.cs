using Autofac;
using Dna.NetCore.Core.BLL.Initializers;
using Dna.NetCore.Core.BLL.Initializers.Common;
using Dna.NetCore.Core.BLL.Initializers.Localization;
using Dna.NetCore.Core.CommandProcessing;
using Dna.NetCore.Core.Commands;
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
                .As<ICommand>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IValidationHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("CrudServices"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("HelperServices"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Queries"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .As<ICommand>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CoreSeedData_enUS>();
            builder.RegisterType<CommonSeedData_enUS>();
            builder.RegisterType<CountrySeedData_enUS>();
            builder.RegisterType<CurrencySeedData_enUS>();
            builder.RegisterType<TimeZoneSeedData_enUS>();
            builder.RegisterType<LocaleSeedData_enUS>();
        }

        #endregion
    }
}
