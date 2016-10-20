using AutoMapper;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.AutoMapper.Common
{
    public partial class CityMapper : ICityMapper
	{
        #region Methods

        public CityCmd GetCmdFromDao(City source)
		{
			CityCmd value = Mapper.Map<CityCmd>(source);
			return value;
		}

        public City GetDaoFromCmd(CityCmd source)
		{
            City value = Mapper.Map<City>(source);
			return value;
		}

        public CityDto GetDtoFromDao(City source)
		{
            CityDto value = Mapper.Map<CityDto>(source);
			return value;
		}

        public IEnumerable<CityDto> GetDtosFromDaos(IEnumerable<City> source)
		{
            CityDto[] value = Mapper.Map<CityDto[]>(source);
			return value;
		}

        public IEnumerable<CitySummary> GetSummariesFromDaos(IEnumerable<City> source)
		{
            CitySummary[] value = Mapper.Map<CitySummary[]>(source);
            return value;
		}

		#endregion
	}
}

