using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using AutoMapper;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Mappers.Common
{
    public partial class CountyMapper : ICountyMapper
	{
        #region Methods

        public CountyCmd GetCmdFromDao(County source)
		{
			CountyCmd value = Mapper.Map<CountyCmd>(source);
			return value;
		}

        public CountyCmd GetCmdFromDto(CountyDto source)
        {
            CountyCmd value = Mapper.Map<CountyCmd>(source);
            return value;
        }

        public County GetDaoFromCmd(CountyCmd source)
		{
            County value = Mapper.Map<County>(source);
			return value;
		}

        public CountyDto GetDtoFromDao(County source)
		{
            CountyDto value = Mapper.Map<CountyDto>(source);
			return value;
		}

        public IEnumerable<CountyDto> GetDtosFromDaos(IEnumerable<County> source)
		{
            CountyDto[] value = Mapper.Map<CountyDto[]>(source);
			return value;
		}

        public IEnumerable<CountySummary> GetSummariesFromDaos(IEnumerable<County> source)
		{
            CountySummary[] value = Mapper.Map<CountySummary[]>(source);
            return value;
		}

		#endregion
	}
}

