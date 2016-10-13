using dao = Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface ITimeZone_Queries
    {
        TimeZoneDto Get(Expression<Func<dao.TimeZone, bool>> wherePredicate);
        TimeZoneCmd GetCmd(string displayName);
        TimeZoneDto GetDefault();
        string GetDefaultTimeZoneInfoId();
        IEnumerable<TimeZoneDto> GetList(bool isActive = true, bool isDeleted = false);
        IEnumerable<TimeZoneDto> GetList(Expression<Func<dao.TimeZone, bool>> wherePredicate);
        IEnumerable<TimeZone_Summary> GetSummaryList(Expression<Func<dao.TimeZone, bool>> wherePredicate);
    }
}