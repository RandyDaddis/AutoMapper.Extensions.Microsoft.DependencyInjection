﻿using System.Collections.Generic;
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
    public partial interface IStateOrProvinceMapper
	{
        StateOrProvinceCmd GetCmdFromDao(StateOrProvince source);
        StateOrProvinceCmd GetCmdFromDto(StateOrProvinceDto source);

        StateOrProvince GetDaoFromCmd(StateOrProvinceCmd source);

        StateOrProvinceDto GetDtoFromDao(StateOrProvince source);

        IEnumerable<StateOrProvinceDto> GetDtosFromDaos(IEnumerable<StateOrProvince> source);

        IEnumerable<StateOrProvince_Summary> GetSummariesFromDaos(IEnumerable<StateOrProvince> source);
    }
}