using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using AutoMapper;
using Dna.NetCore.Core.BLL.Entities.Localization;
using Dna.NetCore.Core.BLL.DataTransferObjects.Localization;

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
            CreateMap<StateOrProvince, StateOrProvince_Summary>();
            CreateMap<Dna.NetCore.Core.BLL.Entities.Common.TimeZone, TimeZone_Summary>();
        }

        #endregion
    }
}
