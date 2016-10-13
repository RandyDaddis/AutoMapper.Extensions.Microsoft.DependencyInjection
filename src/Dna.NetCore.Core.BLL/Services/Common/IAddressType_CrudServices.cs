using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.Common;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface IAddressType_CrudServices
	{
        void Add(AddressTypeCmd cmd, string userName, out CustomMessage customMessage);
        void Delete(AddressTypeDto dto, string userName, out CustomMessage customMessage);
        void Update(AddressTypeCmd cmd, string userName, out CustomMessage customMessage);

        AddressTypeCmd Cmd_Create(string userName, string stateOrProvinceAbbreviation, out CustomMessage customMessage);
        AddressTypeCmd Cmd_SetDefaultPropertyValues(AddressTypeCmd cmd, string userName, string stateOrProvinceAbbreviation);

        //AddressTypeCmd Cmd_SetAscendentProperties(AddressTypeCmd cmd);
    }
}
