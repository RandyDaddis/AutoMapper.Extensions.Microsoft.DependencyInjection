﻿using Autofac;
using Dna.NetCore.Core;
using Dna.NetCore.Core.BLL;
using Dna.NetCore.Core.DAL.AutoMapper;
using Dna.NetCore.Core.DAL.EFCore;

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
            builder.RegisterModule(new AutofacModule_Core());
            builder.RegisterModule(new AutofacModule_CoreBLL());
            builder.RegisterModule(new AutofacModule_CoreDALEFCore());
            builder.RegisterModule(new AutofacModule_CoreDALAutoMapper());

            //return builder;
        }

        #endregion
    }
}