using Dna.NetCore.Core.BLL.Commands.Plugins;
using Dna.NetCore.Core.BLL.DataTransferObjects.Plugins;
using Dna.NetCore.Core.BLL.Entities.Plugins;
using Dna.NetCore.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Plugins
{
    public interface IPlugin_Queries
    {
        PluginDto Get(Expression<Func<Plugin, bool>> wherePredicate);
        PluginCmd GetCmd(int id);
        IEnumerable<PluginDto> GetList(bool isActive = true, bool isDeleted = false);
        IEnumerable<PluginDto> GetList(Expression<Func<Plugin, bool>> wherePredicate);
        IEnumerable<PluginSummary> GetSummaryList(Expression<Func<Plugin, bool>> wherePredicate);
        IPagedList<PluginSummary> GetSummaryPagedList(Expression<Func<Plugin, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10);
        bool HasSystemName(string name);
        bool HasDisplayName(string name);
        bool HasId(int id);
    }
}
