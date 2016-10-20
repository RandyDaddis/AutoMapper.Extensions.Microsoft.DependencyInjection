using AutoMapper;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.Commands.Localization;
using Dna.NetCore.Core.BLL.Commands.Plugins;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Entities.Localization;
using Dna.NetCore.Core.BLL.Entities.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dna.NetCore.Core.DAL.AutoMapper
{
    public class AutoMapperProfile_NetCore_DaoFromCmd : Profile
    {
        #region ctor

        public AutoMapperProfile_NetCore_DaoFromCmd()
        {
            CreateMaps();
        }

        #endregion

        #region Methods

        protected void CreateMaps()
        {
            CreateMap<AddressTypeCmd, AddressType>();
            CreateMap<CityCmd, City>();
            CreateMap<CountyCmd, County>();
            CreateMap<CountyCityCmd, CountyCity>();
            CreateMap<CountryCmd, Country>();
            CreateMap<CurrencyCmd, Currency>();
            CreateMap<ExchangeRateCmd, ExchangeRate>();
            CreateMap<LocaleCmd, Locale>();
            CreateMap<MimeTypeCmd, MimeType>();
            CreateMap<MimeTypeGroupCmd, MimeTypeGroup>();
            CreateMap<PersonTypeCmd, PersonType>();
            CreateMap<PluginCmd, Plugin>();
            CreateMap<PhoneNumberTypeCmd, PhoneNumberType>();
            CreateMap<StateOrProvinceCmd, StateOrProvince>();
            CreateMap<TimeZoneCmd, Dna.NetCore.Core.BLL.Entities.Common.TimeZone>();
        }

        #endregion
    }
}
