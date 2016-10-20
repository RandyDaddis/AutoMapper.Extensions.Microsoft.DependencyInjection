using AutoMapper;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.Commands.Localization;
using Dna.NetCore.Core.BLL.Commands.Plugins;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Entities.Localization;
using Dna.NetCore.Core.BLL.Entities.Plugins;

namespace Dna.NetCore.Core.DAL.AutoMapper
{
    public class AutoMapperProfile_NetCore_CmdFromDao : Profile
    {
        #region ctor

        public AutoMapperProfile_NetCore_CmdFromDao()
        {
            CreateMaps();
        }

        #endregion

        #region Methods

        protected void CreateMaps()
        {
            CreateMap<AddressType, AddressTypeCmd>();
            CreateMap<City, CityCmd>()
            .ForMember(cmd => cmd.StateOrProvinceAbbreviation, opt => opt.Ignore())
            .ForMember(cmd => cmd.StateOrProvinceSummaries, opt => opt.Ignore());
            CreateMap<County, CountyCmd>()
            .ForMember(cmd => cmd.StateOrProvinceAbbreviation, opt => opt.Ignore())
            .ForMember(cmd => cmd.StateOrProvinceSummaries, opt => opt.Ignore());
            CreateMap<CountyCity, CountyCityCmd>();
            CreateMap<Country, CountryCmd>();
            CreateMap<Currency, CurrencyCmd>();
            CreateMap<ExchangeRate, ExchangeRateCmd>();
            CreateMap<Locale, LocaleCmd>();
            CreateMap<MimeType, MimeTypeCmd>();
            CreateMap<MimeTypeGroup, MimeTypeGroupCmd>();
            CreateMap<PersonType, PersonTypeCmd>();
            CreateMap<PhoneNumberType, PhoneNumberTypeCmd>();
            CreateMap<Plugin, PluginCmd>();
            CreateMap<StateOrProvince, StateOrProvinceCmd>()
            .ForMember(cmd => cmd.CountryAbbreviation, opt => opt.MapFrom(s => s.Country.Abbreviation));
            CreateMap<Dna.NetCore.Core.BLL.Entities.Common.TimeZone, TimeZoneCmd>();
        }

        #endregion
    }
}
