using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Mappers.Common
{
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="AutoMapperConfigurationException"></exception>
    /// <exception cref="AutoMapperMappingException"></exception>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public partial interface ICurrencyMapper
	{
        CurrencyCmd GetCmdFromDao(Currency source);
        Currency GetDaoFromCmd(CurrencyCmd source);
        CurrencyDto GetDtoFromDao(Currency source);
        IEnumerable<CurrencyDto> GetDtosFromDaos(IEnumerable<Currency> source);
        IEnumerable<Currency_Summary> GetSummariesFromDaos(IEnumerable<Currency> source);
    }
}
