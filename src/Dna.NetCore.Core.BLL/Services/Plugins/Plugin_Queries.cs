using Dna.NetCore.Core.BLL.Commands.Plugins;
using Dna.NetCore.Core.BLL.DataTransferObjects.Plugins;
using Dna.NetCore.Core.BLL.Entities.Plugins;
using Dna.NetCore.Core.BLL.Mappers.Plugins;
using Dna.NetCore.Core.BLL.Repositories.Plugins;
using Dna.NetCore.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Plugins
{
    public partial class Plugin_Queries : IPlugin_Queries
    {
        #region Private Fields

        private readonly IPluginRepository _repository;
        private readonly IPluginMapper _mapper;

        #endregion

        #region ctor

        public Plugin_Queries(IPluginRepository repository,
                                    IPluginMapper mapper)
		{
			_repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Query Methods

        public virtual PluginDto Get(Expression<Func<Plugin, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            Plugin dao = _repository.Get(wherePredicate);
            PluginDto dto = dao == null ? null : _mapper.GetDtoFromDao(dao);

            return dto;
        }

        public virtual PluginCmd GetCmd(int id)
        {
            if (id < 1) 
                return null;

            Plugin dao = _repository.Get(a => a.Id == id);
            PluginCmd cmd = dao == null ? null : _mapper.GetCmdFromDao(dao);

            return cmd;
        }

        public virtual IEnumerable<PluginDto> GetList(bool isActive = true, bool isDeleted = false)
        {
            return GetList(a => a.IsActive == isActive && a.IsDeleted == isDeleted);
        }

        public virtual IEnumerable<PluginDto> GetList(Expression<Func<Plugin, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<Plugin> daos = _repository.GetWhere(wherePredicate)
                                    .OrderBy(a => a.DisplayName)
                                    .ToList();
            IEnumerable<PluginDto> dtos = _mapper.GetDtosFromDaos(daos);

            return dtos;
        }

        public virtual IEnumerable<PluginSummary> GetSummaryList(Expression<Func<Plugin, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<Plugin> list = _repository.GetWhere(wherePredicate)
                                    .OrderBy(a => a.DisplayName);

            return _mapper.GetSummariesFromDaos(list);
        }

        public virtual IPagedList<PluginSummary> GetSummaryPagedList(Expression<Func<Plugin, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<Plugin> list = _repository.GetWhere(wherePredicate)
                                    .OrderBy(a => a.DisplayName);
            IEnumerable<PluginSummary> summaries = _mapper.GetSummariesFromDaos(list);

            return new PagedList<PluginSummary>(summaries, pageIndex, pageSize);
        }

        public virtual bool HasSystemName(string name)
        {
            bool isFound = _repository.Get(a => a.SystemName == name) != null ? true : false;
            return isFound;
        }

        public virtual bool HasDisplayName(string name)
        {
            bool isFound = _repository.Get(a => a.DisplayName == name) != null ? true : false;
            return isFound;
        }

        public virtual bool HasId(int id)
        {
            bool isFound = _repository.Get(a => a.Id == id) != null ? true : false;

            return isFound;
        }

        #endregion
    }
}
