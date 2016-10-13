using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface ICounty_Queries
	{
        CountyDto Get(int id);
        CountyDto Get(Expression<Func<County, bool>> wherePredicate);

        CountyCmd GetCmd(int id);

        //int GetId(string displayName);

        //IEnumerable<CountyDto> GetList(bool isActive = true);
        IEnumerable<CountyDto> GetList(Expression<Func<County, bool>> wherePredicate);

        IEnumerable<CountySummary> GetSummaryList(Expression<Func<County, bool>> wherePredicate);
        IPagedList<CountySummary> GetSummaryPagedList(Expression<Func<County, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10);

        bool HasDisplayName(string name);
    }
}
