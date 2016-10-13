using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface IStateOrProvince_Queries
	{
        //StateOrProvinceDto Get(int id);
        StateOrProvinceDto Get(Expression<Func<StateOrProvince, bool>> wherePredicate);
        StateOrProvinceCmd GetCmd(int id);
        StateOrProvinceDto GetDefault();
        string GetDefaultAbbreviation();
        IEnumerable<StateOrProvinceDto> GetList(bool isActive = true, bool isDeleted = false);
        IEnumerable<StateOrProvinceDto> GetList(Expression<Func<StateOrProvince, bool>> wherePredicate);
        IEnumerable<StateOrProvince_Summary> GetSummaryList(Expression<Func<StateOrProvince, bool>> wherePredicate);
        IPagedList<StateOrProvince_Summary> GetSummaryPagedList(Expression<Func<StateOrProvince, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10);
        bool HasAbbreviation(string name);
        bool HasName(string name);
    }
}
