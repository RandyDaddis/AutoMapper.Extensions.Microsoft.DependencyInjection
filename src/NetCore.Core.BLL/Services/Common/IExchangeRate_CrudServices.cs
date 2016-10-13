using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.Common;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface IExchangeRate_CrudServices
	{
        void Add(ExchangeRateCmd cmd, string userName, out CustomMessage customMessage);
        void Delete(ExchangeRateDto dto, string userName, out CustomMessage customMessage);
        void Update(ExchangeRateCmd cmd, string userName, out CustomMessage customMessage);

        ExchangeRateCmd Cmd_Create(string userName, out CustomMessage customMessage);
        ExchangeRateCmd Cmd_SetDefaultPropertyValues(ExchangeRateCmd cmd, string userName);
    }
}
