using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dna.NetCore.Core.BLL.Entities;
using Dna.NetCore.Core.BLL.Constants;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class Currency_Queries : ICurrency_Queries
    {
        #region Private Fields

        private readonly ICurrencyRepository _repository;
        private readonly ICurrencyMapper _mapper;
        private readonly ISystemSetting_Queries _systemSettingQueries;

        #endregion

        #region ctor

        public Currency_Queries(ICurrencyRepository repository,
                                ICurrencyMapper mapper,
                                ISystemSetting_Queries systemSettingQueries)
        {
            _repository = repository;
            _mapper = mapper;
            _systemSettingQueries = systemSettingQueries;
        }

        #endregion

        #region Query Methods

        public virtual CurrencyDto Get(Expression<Func<Currency, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            Currency dao = _repository.Get(wherePredicate);
            CurrencyDto dto = dao == null ? null : _mapper.GetDtoFromDao(dao);

            return dto;
        }

        public virtual CurrencyCmd GetCmd(Expression<Func<Currency, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            Currency dao = _repository.Get(wherePredicate);
            CurrencyCmd cmd = dao == null ? null : _mapper.GetCmdFromDao(dao);

            return cmd;
        }

        public virtual CurrencyDto GetDefault()
        {
            CurrencyDto dto = null;

            string code = GetDefaultCode();
            if (!string.IsNullOrEmpty(code))
                dto = this.Get(a => a.Code == code);
            return dto;
        }

        public virtual string GetDefaultCode()
        {
            string code = "";

            SystemSetting systemSetting = _systemSettingQueries.Get(j => j.SystemName == SystemSettingConstants.Core_CurrencyCode);

            if (systemSetting != null)
                code = systemSetting.StringValue;

            return code;
        }

        public virtual IEnumerable<CurrencyDto> GetList(bool isActive = true, bool isDeleted = false)
        {
            return GetList(a => a.IsActive == isActive && a.IsDeleted == isDeleted);
        }

        public virtual IEnumerable<CurrencyDto> GetList(Expression<Func<Currency, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<Currency> daos = _repository.GetWhere(wherePredicate)
                                                    .OrderBy(a => a.DisplayName)
                                                    .ToList();
            IEnumerable<CurrencyDto> dtos = _mapper.GetDtosFromDaos(daos);
            return dtos;
        }

        public virtual IEnumerable<Currency_Summary> GetSummaryList(Expression<Func<Currency, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;
            IEnumerable<Currency> list = _repository.GetWhere(wherePredicate)
                                                    .OrderBy(a => a.DisplayName);
            return _mapper.GetSummariesFromDaos(list);
        }

        public virtual IPagedList<Currency_Summary> GetSummaryPagedList(Expression<Func<Currency, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<Currency> list = _repository.GetWhere(wherePredicate)
                                                    .OrderBy(a => a.DisplayName);
            IEnumerable<Currency_Summary> summaries = _mapper.GetSummariesFromDaos(list);

            return new PagedList<Currency_Summary>(summaries, pageIndex, pageSize);
        }

        public virtual bool HasName(string name)
        {
            bool isFound = _repository.Get(a => a.DisplayName == name) != null ? true : false;
            return isFound;
        }

        public virtual bool HasCode(string name)
        {
            bool isFound = _repository.Get(a => a.Code == name) != null ? true : false;
            return isFound;
        }

        #endregion
    }
}
