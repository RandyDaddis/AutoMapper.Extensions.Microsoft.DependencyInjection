using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using AutoMapper;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Mappers.Common
{
    public partial class CountyCityMapper : ICountyCityMapper
	{
        #region Methods

        public CountyCityCmd GetCmdFromDao(CountyCity source)
		{
			CountyCityCmd value = Mapper.Map<CountyCityCmd>(source);
			return value;
		}

        public CountyCityCmd GetCmdFromDto(CountyCityDto source)
        {
            CountyCityCmd value = Mapper.Map<CountyCityCmd>(source);
            return value;
        }

        public CountyCity GetDaoFromCmd(CountyCityCmd source)
		{
            CountyCity value = Mapper.Map<CountyCity>(source);
			return value;
		}

        public CountyCityDto GetDtoFromDao(CountyCity source)
		{
            CountyCityDto value = Mapper.Map<CountyCityDto>(source);
			return value;
		}

        public IEnumerable<CountyCityDto> GetDtosFromDaos(IEnumerable<CountyCity> source)
		{
            CountyCityDto[] value = Mapper.Map<CountyCityDto[]>(source);
			return value;
		}

		#endregion
	}
}

