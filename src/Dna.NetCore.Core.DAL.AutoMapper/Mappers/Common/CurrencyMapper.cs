using AutoMapper;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.AutoMapper.Common
{
    public partial class CurrencyMapper : ICurrencyMapper
	{
        #region Methods

        public CurrencyCmd GetCmdFromDao(Currency source)
		{
			CurrencyCmd value = Mapper.Map<CurrencyCmd>(source);
			return value;
		}

        public Currency GetDaoFromCmd(CurrencyCmd source)
		{
            Currency value = Mapper.Map<Currency>(source);
			return value;
		}

        public CurrencyDto GetDtoFromDao(Currency source)
		{
            CurrencyDto value = Mapper.Map<CurrencyDto>(source);
			return value;
		}

        public IEnumerable<CurrencyDto> GetDtosFromDaos(IEnumerable<Currency> source)
		{
            CurrencyDto[] value = Mapper.Map<CurrencyDto[]>(source);
			return value;
		}

        public IEnumerable<Currency_Summary> GetSummariesFromDaos(IEnumerable<Currency> source)
		{
            Currency_Summary[] value = Mapper.Map<Currency_Summary[]>(source);
			return value;
		}

		#endregion
	}
}

