using Dna.NetCore.Core.BLL.Entities.Common;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface ISystemSetting_Queries
    {
        SystemSetting Get(int id);
        SystemSetting Get(string systemName);
        SystemSetting Get(Expression<Func<SystemSetting, bool>> wherePredicate);
        IQueryable<SystemSetting> GetList(Expression<Func<SystemSetting, bool>> wherePredicate);

        //int GetDefaultSystemSettingId(string systemName);

        bool IsDeleteEntityPermanent();
    }
}