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
    public partial interface IExchangeRateMapper
	{
        ExchangeRateCmd GetCmdFromDao(ExchangeRate source);
        ExchangeRate GetDaoFromCmd(ExchangeRateCmd source);
        ExchangeRateDto GetDtoFromDao(ExchangeRate source);
        IEnumerable<ExchangeRateDto> GetDtosFromDaos(IEnumerable<ExchangeRate> source);
        IEnumerable<ExchangeRate_Summary> GetSummariesFromDaos(IEnumerable<ExchangeRate> source);
    }
}
