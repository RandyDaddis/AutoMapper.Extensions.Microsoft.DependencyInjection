using System.Collections.Generic;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;

namespace Dna.NetCore.Core.BLL.Mappers.Common
{
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="AutoMapperConfigurationException"></exception>
	/// <exception cref="AutoMapperMappingException"></exception>
	/// <exception cref="NullReferenceException"></exception>
	/// <exception cref="ArgumentNullException"></exception>
	/// <exception cref="ArgumentException"></exception>
    public partial interface ICountryMapper
	{
        CountryCmd GetCmdFromDao(Country source);
        Country GetDaoFromCmd(CountryCmd source);
        CountryDto GetDtoFromDao(Country source);
        IEnumerable<CountryDto> GetDtosFromDaos(IEnumerable<Country> source);
        IEnumerable<CountrySummary> GetSummariesFromDaos(IEnumerable<Country> source);
    }
}
