using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.Common;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface ICity_CrudServices
	{
        void Add(CityCmd cmd, string userName, out CustomMessage customMessage);
        void Delete(CityDto dto, string userName, out CustomMessage customMessage);
        void Update(CityCmd cmd, string userName, out CustomMessage customMessage);

        CityCmd Cmd_Create(string userName, string stateOrProvinceAbbreviation, out CustomMessage customMessage);
        CityCmd Cmd_SetDefaultPropertyValues(CityCmd cmd, string userName, string stateOrProvinceAbbreviation);

        //CityCmd Cmd_SetAscendentProperties(CityCmd cmd);
    }
}
