using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface ICity_Queries
	{
        CityDto Get(int id);
        CityDto Get(Expression<Func<City, bool>> wherePredicate);

        CityCmd GetCmd(int id);

        //int GetId(string displayName);

        //IEnumerable<CityDto> GetList(bool isActive = true);
        IEnumerable<CityDto> GetList(Expression<Func<City, bool>> wherePredicate);

        IEnumerable<CitySummary> GetSummaryList(Expression<Func<City, bool>> wherePredicate);
        IPagedList<CitySummary> GetSummaryPagedList(Expression<Func<City, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10);

        bool HasDisplayName(string displayName);
    }
}
