using AutoMapper;
using NetCore.Core.BLL.DataTransferObjects;
using NetCore.Core.BLL.Entities;

namespace NetCore.Core.BLL.Mappers
{
    public partial class AddressTypeMapper : IAddressTypeMapper
    {
        #region Methods

        public AddressTypeDto GetDtoFromDao(AddressType source)
		{
            AddressTypeDto value = Mapper.Map<AddressTypeDto>(source);
			return value;
		}

		#endregion
	}
}

