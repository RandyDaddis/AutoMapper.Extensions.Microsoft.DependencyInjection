using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using AutoMapper;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Mappers.Common
{
    public partial class StateOrProvinceMapper : IStateOrProvinceMapper
	{
        #region Methods

        public StateOrProvinceCmd GetCmdFromDao(StateOrProvince source)
		{
			StateOrProvinceCmd value = Mapper.Map<StateOrProvinceCmd>(source);
			return value;
		}

        public StateOrProvinceCmd GetCmdFromDto(StateOrProvinceDto source)
        {
            StateOrProvinceCmd value = Mapper.Map<StateOrProvinceCmd>(source);
            return value;
        }

        public StateOrProvince GetDaoFromCmd(StateOrProvinceCmd source)
		{
            StateOrProvince value = Mapper.Map<StateOrProvince>(source);
			return value;
		}

        public StateOrProvinceDto GetDtoFromDao(StateOrProvince source)
		{
            StateOrProvinceDto value = Mapper.Map<StateOrProvinceDto>(source);
			return value;
		}

        public IEnumerable<StateOrProvinceDto> GetDtosFromDaos(IEnumerable<StateOrProvince> source)
		{
            StateOrProvinceDto[] value = Mapper.Map<StateOrProvinceDto[]>(source);
			return value;
		}

        public IEnumerable<StateOrProvince_Summary> GetSummariesFromDaos(IEnumerable<StateOrProvince> source)
		{
            StateOrProvince_Summary[] value = Mapper.Map<StateOrProvince_Summary[]>(source);
			return value;
		}

		#endregion
	}
}

