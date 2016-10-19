using AutoMapper;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.AutoMapper.Common
{
    public partial class AddressTypeMapper : IAddressTypeMapper
    {
        #region Methods

        public AddressTypeCmd GetCmdFromDao(AddressType source)
		{
			AddressTypeCmd value = Mapper.Map<AddressTypeCmd>(source);
			return value;
		}

        public AddressTypeCmd GetCmdFromDto(AddressTypeDto source)
        {
            AddressTypeCmd value = Mapper.Map<AddressTypeCmd>(source);
            return value;
        }

        public AddressType GetDaoFromCmd(AddressTypeCmd source)
		{
            AddressType value = Mapper.Map<AddressType>(source);
			return value;
		}

        public AddressTypeDto GetDtoFromDao(AddressType source)
		{
            AddressTypeDto value = Mapper.Map<AddressTypeDto>(source);
			return value;
		}

        public IEnumerable<AddressTypeDto> GetDtosFromDaos(IEnumerable<AddressType> source)
		{
            AddressTypeDto[] value = Mapper.Map<AddressTypeDto[]>(source);
			return value;
		}

        public IEnumerable<AddressTypeSummary> GetSummariesFromDaos(IEnumerable<AddressType> source)
		{
            AddressTypeSummary[] value = Mapper.Map<AddressTypeSummary[]>(source);
			return value;
		}

		#endregion
	}
}

