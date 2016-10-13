using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.Common;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface ICounty_CrudServices
	{
        void Add(CountyCmd cmd, string userName, out CustomMessage customMessage);
        void Delete(CountyDto dto, string userName, out CustomMessage customMessage);
        void Update(CountyCmd cmd, string userName, out CustomMessage customMessage);

        CountyCmd Cmd_Create(string userName, string stateOrProvinceAbbreviation, out CustomMessage customMessage);
        CountyCmd Cmd_SetDefaultPropertyValues(CountyCmd cmd, string userName, string stateOrProvinceAbbreviation);

        //CountyCmd Cmd_SetAscendentProperties(CountyCmd cmd);
    }
}
