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
    public partial interface IAddressTypeMapper
	{
        AddressTypeCmd GetCmdFromDao(AddressType source);
        AddressTypeCmd GetCmdFromDto(AddressTypeDto source);
        AddressType GetDaoFromCmd(AddressTypeCmd source);
        AddressTypeDto GetDtoFromDao(AddressType source);
        IEnumerable<AddressTypeDto> GetDtosFromDaos(IEnumerable<AddressType> source);
        IEnumerable<AddressTypeSummary> GetSummariesFromDaos(IEnumerable<AddressType> source);
    }
}