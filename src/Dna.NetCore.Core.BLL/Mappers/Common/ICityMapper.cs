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
    public partial interface ICityMapper
	{
        CityCmd GetCmdFromDao(City source);
        City GetDaoFromCmd(CityCmd source);
        CityDto GetDtoFromDao(City source);
        IEnumerable<CityDto> GetDtosFromDaos(IEnumerable<City> source);
        IEnumerable<CitySummary> GetSummariesFromDaos(IEnumerable<City> source);
    }
}
