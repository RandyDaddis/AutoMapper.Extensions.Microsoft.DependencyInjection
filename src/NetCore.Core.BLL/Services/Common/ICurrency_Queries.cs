using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface ICurrency_Queries
	{
		//decimal ConvertCurrency(decimal amount, decimal exchangeRate);
		//decimal ConvertCurrency(decimal amount, CurrencyDto sourceCurrency, CurrencyDto targetCurrency);

		//decimal ConvertFromPrimaryExchangeRate(decimal amount, CurrencyDto targetCurrency);
		//decimal ConvertToPrimaryExchangeRate(decimal amount, CurrencyDto sourceCurrency);
		//IExchangeRateProvider GetActiveExchangeRateProvider();
		//IExchangeRateProvider GetExchangeRateProviderBySystemName(string systemName);
		//IList<IExchangeRateProvider> GetAllExchangeRateProviders();
		//IList<ExchangeRate> GetExchangeRatesForExchangeRateCurrencyCode(string currencyCode);

        CurrencyDto Get(Expression<Func<Currency, bool>> wherePredicate);
        CurrencyCmd GetCmd(Expression<Func<Currency, bool>> wherePredicate);
        CurrencyDto GetDefault();
        string GetDefaultCode();
        IEnumerable<CurrencyDto> GetList(bool isActive = true, bool isDeleted = false);
        IEnumerable<CurrencyDto> GetList(Expression<Func<Currency, bool>> wherePredicate);
        IEnumerable<Currency_Summary> GetSummaryList(Expression<Func<Currency, bool>> wherePredicate);
        IPagedList<Currency_Summary> GetSummaryPagedList(Expression<Func<Currency, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10);
        bool HasName(string name);
        bool HasCode(string name);

    }
}
