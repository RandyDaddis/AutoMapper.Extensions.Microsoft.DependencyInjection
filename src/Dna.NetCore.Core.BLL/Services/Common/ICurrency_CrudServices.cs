using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.Common;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface ICurrency_CrudServices
	{
        void Add(CurrencyCmd cmd, string userName, out CustomMessage customMessage);
        void Delete(CurrencyDto dto, string userName, out CustomMessage customMessage);
        void Update(CurrencyCmd cmd, string userName, out CustomMessage customMessage);

        CurrencyCmd Cmd_Create(string userName, out CustomMessage customMessage);
        CurrencyCmd Cmd_SetDefaultPropertyValues(CurrencyCmd cmd, string userName);
    }
}
