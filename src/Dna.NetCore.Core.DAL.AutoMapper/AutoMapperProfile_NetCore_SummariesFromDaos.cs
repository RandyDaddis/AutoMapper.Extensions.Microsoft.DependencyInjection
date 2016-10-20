using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using AutoMapper;
using Dna.NetCore.Core.BLL.Entities.Localization;
using Dna.NetCore.Core.BLL.DataTransferObjects.Localization;
using Dna.NetCore.Core.BLL.Entities.Plugins;
using Dna.NetCore.Core.BLL.DataTransferObjects.Plugins;

namespace Dna.NetCore.Core.DAL.AutoMapper
{
    public class AutoMapperProfile_NetCore_SummariesFromDaos : Profile
    {
        #region ctor

        public AutoMapperProfile_NetCore_SummariesFromDaos()
        {
            CreateMaps();
        }

        #endregion

        #region Methods

        protected void CreateMaps()
        {
            CreateMap<AddressType, AddressTypeSummary>();
            CreateMap<PersonType, PersonType_Summary>();
            CreateMap<County, CountySummary>();
            CreateMap<Country, CountrySummary>();
            CreateMap<Currency, Currency_Summary>();
            CreateMap<ExchangeRate, ExchangeRate_Summary>();
            CreateMap<Locale, Locale_Summary>();
            CreateMap<Plugin, PluginSummary>();
            CreateMap<StateOrProvince, StateOrProvince_Summary>();
            CreateMap<Dna.NetCore.Core.BLL.Entities.Common.TimeZone, TimeZone_Summary>();
        }

        #endregion
    }
}
