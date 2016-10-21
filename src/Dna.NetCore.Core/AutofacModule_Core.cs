using Dna.NetCore.Core.Common;
using Autofac;
using System.Reflection;
using Dna.NetCore.Core.CommandProcessing;

namespace Dna.NetCore.Core
{
    public class AutofacModule_Core : Autofac.Module
    {
        #region ctor

        public AutofacModule_Core()
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
            Assembly assembly = Assembly.Load(new AssemblyName("Dna.NetCore.Core"));

            builder.RegisterType<CommandBus>().As<ICommandBus>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DateTimeAdapter>()
                .As<IDateTimeAdapter>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Handler"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("MessageBuilder"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("MessageHandler"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(PagedList<>)).As(typeof(IPagedList<>));
        }

        #endregion
    }
}
