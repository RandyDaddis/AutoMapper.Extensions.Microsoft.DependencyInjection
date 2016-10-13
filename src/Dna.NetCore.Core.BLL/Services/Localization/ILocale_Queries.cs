using Dna.NetCore.Core.BLL.Commands.Localization;
using Dna.NetCore.Core.BLL.DataTransferObjects.Localization;
using Dna.NetCore.Core.BLL.Entities.Localization;
using Dna.NetCore.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Localization
{
    public interface ILocale_Queries
    {
        LocaleDto Get(Expression<Func<Locale, bool>> wherePredicate);
        LocaleCmd GetCmd(Expression<Func<Locale, bool>> wherePredicate);
        LocaleDto GetDefault();
        int GetDefaultLcidDecimal();
        IEnumerable<LocaleDto> GetList(bool isActive = true, bool isDeleted = false);
        IEnumerable<LocaleDto> GetList(Expression<Func<Locale, bool>> wherePredicate);
        IEnumerable<Locale_Summary> GetSummaryList(Expression<Func<Locale, bool>> wherePredicate);
        IPagedList<Locale_Summary> GetSummaryPagedList(Expression<Func<Locale, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10);
        bool HasName(string name);
        bool HasLCIDDecimal(int lCIDDecimal);
    }
}
