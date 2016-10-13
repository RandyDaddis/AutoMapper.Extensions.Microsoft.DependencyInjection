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
    public partial interface ICountyMapper
	{
        CountyCmd GetCmdFromDao(County source);
        CountyCmd GetCmdFromDto(CountyDto source);

        County GetDaoFromCmd(CountyCmd source);

        CountyDto GetDtoFromDao(County source);

        IEnumerable<CountyDto> GetDtosFromDaos(IEnumerable<County> source);

        IEnumerable<CountySummary> GetSummariesFromDaos(IEnumerable<County> source);
    }
}
