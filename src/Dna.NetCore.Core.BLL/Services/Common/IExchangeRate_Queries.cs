using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface IExchangeRate_Queries
	{
        ExchangeRateDto Get(int id);
        ExchangeRateDto Get(Expression<Func<ExchangeRate, bool>> wherePredicate);

        ExchangeRateCmd GetCmd(int id);

        int GetId(string displayName);

        IEnumerable<ExchangeRateDto> GetList(bool isActive = true);
        IEnumerable<ExchangeRateDto> GetList(Expression<Func<ExchangeRate, bool>> wherePredicate);

        IEnumerable<ExchangeRate_Summary> GetSummaryList(Expression<Func<ExchangeRate, bool>> wherePredicate);
        IPagedList<ExchangeRate_Summary> GetSummaryPagedList(Expression<Func<ExchangeRate, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10);

        bool HasSystemName(string name);
        bool HasDisplayName(string name);

    }
}
