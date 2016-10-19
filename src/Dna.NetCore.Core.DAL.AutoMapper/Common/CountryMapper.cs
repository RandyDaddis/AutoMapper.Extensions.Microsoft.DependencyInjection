using AutoMapper;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.AutoMapper.Common
{
    public partial class CountryMapper : ICountryMapper
	{
        #region Methods

        public CountryCmd GetCmdFromDao(Country source)
		{
			CountryCmd value = Mapper.Map<CountryCmd>(source);
			return value;
		}

        public CountryCmd GetCmdFromDto(CountryDto source)
        {
            CountryCmd value = Mapper.Map<CountryCmd>(source);
            return value;
        }

        public Country GetDaoFromCmd(CountryCmd source)
		{
            Country value = Mapper.Map<Country>(source);
			return value;
		}

        public CountryDto GetDtoFromDao(Country source)
		{
            CountryDto value = Mapper.Map<CountryDto>(source);
			return value;
		}

        public IEnumerable<CountryDto> GetDtosFromDaos(IEnumerable<Country> source)
		{
            CountryDto[] value = Mapper.Map<CountryDto[]>(source);
			return value;
		}

        public IEnumerable<CountrySummary> GetSummariesFromDaos(IEnumerable<Country> source)
		{
            CountrySummary[] value = Mapper.Map<CountrySummary[]>(source);
            return value;
		}

		#endregion
	}
}

