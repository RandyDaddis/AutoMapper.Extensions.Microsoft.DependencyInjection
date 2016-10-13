using NetCore.Core.BLL.DataTransferObjects;
using NetCore.Core.BLL.Entities;

namespace NetCore.Core.BLL.Mappers
{

    public partial interface IAddressTypeMapper
	{
        AddressTypeDto GetDtoFromDao(AddressType source);
    }
}
