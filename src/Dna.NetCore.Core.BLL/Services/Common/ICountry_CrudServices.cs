using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.Common;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface ICountry_CrudServices
	{
        void Add(CountryCmd cmd, string userName, out CustomMessage customMessage);
        void Delete(CountryDto dto, string userName, out CustomMessage customMessage);
        void Update(CountryCmd cmd, string userName, out CustomMessage customMessage);
        CountryCmd Cmd_Create(string userName, out CustomMessage customMessage, string phoneNumberCountryCode = "", string currencyCode = "", int lcidDecimal = 0);
        CountryCmd Cmd_SetDefaultPropertyValues(CountryCmd cmd, string userName, string phoneNumberCountryCode = "", string currencyCode = "", int lcidDecimal = 0);
    }
}
