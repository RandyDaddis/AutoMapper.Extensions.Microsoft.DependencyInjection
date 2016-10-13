using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface ICountry_Queries
	{
        CountryDto Get(Expression<Func<Country, bool>> wherePredicate);
        CountryCmd GetCmd(string abbreviation);
        CountryDto GetDefault();
        string GetDefaultAbbreviation();
        IEnumerable<CountryDto> GetList(bool isActive = true, bool isDeleted = false);
        IEnumerable<CountryDto> GetList(Expression<Func<Country, bool>> wherePredicate);
        IEnumerable<CountrySummary> GetSummaryList(Expression<Func<Country, bool>> wherePredicate);
        IPagedList<CountrySummary> GetSummaryPagedList(Expression<Func<Country, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10);
        bool HasAbbreviation(string name);
        bool HasDisplayName(string name);
    }
}
