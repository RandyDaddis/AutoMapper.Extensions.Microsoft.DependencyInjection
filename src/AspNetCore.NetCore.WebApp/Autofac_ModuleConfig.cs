using Autofac;
using NetCore.Core.BLL;
using NetCore.Core.DAL.EFCore;

namespace AspNetCore.NetCore.WebApp
{
    public class AutofacModuleConfig : Autofac.Module
    {
        #region ctor

        public AutofacModuleConfig() 
        {
        }

        #endregion

        #region methods

        protected override void Load(ContainerBuilder builder)
        {
            // TODO: assembly scanning
            // http://docs.autofac.org/en/latest/register/scanning.html

            builder.RegisterModule(new AutofacModule_WebApp());

            builder.RegisterModule(new AutofacModule_CoreBLL());
            builder.RegisterModule(new AutofacModule_CoreDALEFCore());

            //return builder;
        }

        #endregion
    }
}