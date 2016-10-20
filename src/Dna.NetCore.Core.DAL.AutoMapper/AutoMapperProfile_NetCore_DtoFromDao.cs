using AutoMapper;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Localization;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Entities.Localization;

namespace Dna.NetCore.Core.DAL.AutoMapper
{
    public class AutoMapperProfile_NetCore_DtoFromDao : Profile
    {
        #region ctor

        public AutoMapperProfile_NetCore_DtoFromDao()
        {
            CreateMaps();
        }

        #endregion

        #region Methods

        protected void CreateMaps()
        {
            CreateMap<AddressType, AddressTypeDto>();
            CreateMap<City, CityDto>()
                .ForMember(dto => dto.StateOrProvinceAbbreviation, opt => opt.Ignore())
                .ForMember(dto => dto.StateOrProvinceSummaries, opt => opt.Ignore());
            CreateMap<Country, CountryDto>();
            CreateMap<County, CountyDto>()
                .ForMember(dto => dto.StateOrProvinceAbbreviation, opt => opt.Ignore())
                .ForMember(dto => dto.StateOrProvinceSummaries, opt => opt.Ignore());
            CreateMap<CountyCity, CountyCityDto>();
            CreateMap<Currency, CurrencyDto>();
            CreateMap<ExchangeRate, ExchangeRateDto>();
            CreateMap<Locale, LocaleDto>();
            CreateMap<MimeType, MimeTypeDto>();
            CreateMap<MimeTypeGroup, MimeTypeGroupDto>();
            CreateMap<PersonType, PersonTypeDto>();
            CreateMap<PhoneNumberType, PhoneNumberTypeDto>();
            CreateMap<StateOrProvince, StateOrProvinceDto>()
                .ForMember(dto => dto.CountryAbbreviation, opt => opt.MapFrom(s => s.Country.Abbreviation));
            CreateMap<Dna.NetCore.Core.BLL.Entities.Common.TimeZone, TimeZoneDto>();
        }

        #endregion
    }
}
