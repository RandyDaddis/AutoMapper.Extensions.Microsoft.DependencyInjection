using AutoMapper;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.AutoMapper.Common
{
    public partial class ExchangeRateMapper : IExchangeRateMapper
	{
        #region Methods

        public ExchangeRateCmd GetCmdFromDao(ExchangeRate source)
		{
			ExchangeRateCmd value = Mapper.Map<ExchangeRateCmd>(source);
			return value;
		}

        public ExchangeRateCmd GetCmdFromDto(ExchangeRateDto source)
        {
            ExchangeRateCmd value = Mapper.Map<ExchangeRateCmd>(source);
            return value;
        }

        public ExchangeRate GetDaoFromCmd(ExchangeRateCmd source)
		{
            ExchangeRate value = Mapper.Map<ExchangeRate>(source);
			return value;
		}

        public ExchangeRateDto GetDtoFromDao(ExchangeRate source)
		{
            ExchangeRateDto value = Mapper.Map<ExchangeRateDto>(source);
			return value;
		}

        public IEnumerable<ExchangeRateDto> GetDtosFromDaos(IEnumerable<ExchangeRate> source)
		{
            ExchangeRateDto[] value = Mapper.Map<ExchangeRateDto[]>(source);
			return value;
		}

        public IEnumerable<ExchangeRate_Summary> GetSummariesFromDaos(IEnumerable<ExchangeRate> source)
		{
            ExchangeRate_Summary[] value = Mapper.Map<ExchangeRate_Summary[]>(source);
			return value;
		}

		#endregion
	}
}

