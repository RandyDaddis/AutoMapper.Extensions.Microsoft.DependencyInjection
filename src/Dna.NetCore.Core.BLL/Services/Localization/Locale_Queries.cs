using Dna.NetCore.Core.BLL.Commands.Localization;
using Dna.NetCore.Core.BLL.DataTransferObjects.Localization;
using Dna.NetCore.Core.BLL.Entities.Localization;
using Dna.NetCore.Core.BLL.Repositories.Localization;
using Dna.NetCore.Core.BLL.Mappers.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dna.NetCore.Core.BLL.Constants;
using Dna.NetCore.Core.BLL.Entities;

namespace Dna.NetCore.Core.BLL.Services.Localization
{
    public partial class Locale_Queries : ILocale_Queries
    {
        #region Private Fields

        private readonly ILocaleRepository _repository;
        private readonly ILocaleMapper _mapper;
        private readonly ISystemSetting_Queries _systemSettingQueries;

        #endregion

        #region ctor

        public Locale_Queries(ILocaleRepository repository,
                                    ILocaleMapper mapper,
                                ISystemSetting_Queries systemSettingQueries)
		{
			_repository = repository;
            _mapper = mapper;
            _systemSettingQueries = systemSettingQueries;
        }

        #endregion

        #region Query Methods

        public virtual LocaleDto Get(Expression<Func<Locale, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            Locale dao = _repository.Get(wherePredicate);
            LocaleDto dto = dao == null ? null : _mapper.GetDtoFromDao(dao);
            return dto;
        }

        public virtual LocaleCmd GetCmd(Expression<Func<Locale, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            Locale dao = _repository.Get(wherePredicate);
            LocaleCmd cmd = dao == null ? null : _mapper.GetCmdFromDao(dao);
            return cmd;
        }

        public virtual LocaleDto GetDefault()
        {
            LocaleDto dto = null;

            int lcid = GetDefaultLcidDecimal();
            if (lcid > 0)
                dto = this.Get(a => a.LCIDDecimal == lcid);

            return dto;
        }

        public virtual int GetDefaultLcidDecimal()
        {
            int lcid = 0;

            SystemSetting systemSetting = _systemSettingQueries.Get(j => j.SystemName == SystemSettingConstants.Core_LocaleLcidDecimal);
            if (systemSetting != null)
                lcid = systemSetting.IntegerValue;

            return lcid;
        }

        public virtual IEnumerable<LocaleDto> GetList(bool isActive = true, bool isDeleted = false)
        {
            return GetList(a => a.IsActive == isActive && a.IsDeleted == isDeleted);
        }

        public virtual IEnumerable<LocaleDto> GetList(Expression<Func<Locale, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<Locale> daos = _repository.GetWhere(wherePredicate)
                                    .OrderBy(a => a.LCIDHexadecimal).ThenBy(a => a.DisplayName)
                                    .ToList();
            IEnumerable<LocaleDto> dtos = _mapper.GetDtosFromDaos(daos);
            return dtos;
        }

        public virtual IEnumerable<Locale_Summary> GetSummaryList(Expression<Func<Locale, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<Locale> list = _repository.GetWhere(wherePredicate)
                                                  .OrderBy(a => a.LCIDHexadecimal)
                                                  .ThenBy(a => a.DisplayName);
            return _mapper.GetSummariesFromDaos(list);
        }

        public virtual IPagedList<Locale_Summary> GetSummaryPagedList(Expression<Func<Locale, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<Locale> list = _repository.GetWhere(wherePredicate)
                                                  .OrderBy(a => a.LCIDHexadecimal)
                                                  .ThenBy(a => a.DisplayName);
            IEnumerable<Locale_Summary> summaries = _mapper.GetSummariesFromDaos(list);
            return new PagedList<Locale_Summary>(summaries, pageIndex, pageSize);
        }

        public virtual bool HasName(string name)
        {
            bool isFound = _repository.Get(a => a.DisplayName == name) != null ? true : false;
            return isFound;
        }

        public virtual bool HasLCIDDecimal(int lCIDDecimal)
        {
            bool isFound = _repository.Get(a => a.LCIDDecimal == lCIDDecimal) != null ? true : false;
            return isFound;
        }

        #endregion
    }
}
