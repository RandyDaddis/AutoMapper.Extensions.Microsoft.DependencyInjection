using dao = Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using System.Linq.Expressions;
using System.Linq;
using System;
using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities;
using Dna.NetCore.Core.BLL.Constants;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class TimeZone_Queries : ITimeZone_Queries
    {
        #region Private Fields

        private readonly ITimeZoneRepository _repository;
        private readonly ITimeZoneMapper _mapper;
        private readonly ISystemSetting_Queries _systemSettingQueries;

        #endregion

        #region ctor

        public TimeZone_Queries(ITimeZoneRepository repository, 
                                ITimeZoneMapper mapper,
                                ISystemSetting_Queries systemSettingQueries)
        {
            _repository = repository;
            _mapper = mapper;
            _systemSettingQueries = systemSettingQueries;
        }

        #endregion

        #region Methods

        public virtual TimeZoneDto Get(Expression<Func<dao.TimeZone, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;
            TimeZoneDto dto = null;

            dao.TimeZone dao = _repository.Get(wherePredicate);
            if (dao != null)
                dto = _mapper.GetDtoFromDao(dao);

            return dto;
        }

        public virtual TimeZoneCmd GetCmd(string displayName)
        {
            if (string.IsNullOrEmpty(displayName))
                return null;
            TimeZoneCmd cmd = null;

            dao.TimeZone dao = _repository.Get(a => a.DisplayName == displayName);
            if (dao != null)
                cmd = _mapper.GetCmdFromDao(dao);

            return cmd;
        }

        public virtual TimeZoneDto GetDefault()
        {
            TimeZoneDto dto = null;

            string timeZoneInfoId = GetDefaultTimeZoneInfoId();
            if (!string.IsNullOrEmpty(timeZoneInfoId))
                dto = this.Get(a => a.TimeZoneInfoId == timeZoneInfoId);

            return dto;
        }

        public virtual string GetDefaultTimeZoneInfoId()
        {
            string timeZoneInfoId = "";

            SystemSetting systemSetting = _systemSettingQueries.Get(j => j.SystemName == SystemSettingConstants.Core_TimeZoneInfoId);
            if (systemSetting != null)
                timeZoneInfoId = systemSetting.StringValue;

            return timeZoneInfoId;
        }

        public virtual IEnumerable<TimeZoneDto> GetList(bool isActive = true, bool isDeleted = false)
        {
            return GetList(a => a.IsActive == isActive && a.IsDeleted == isDeleted);
        }

        public virtual IEnumerable<TimeZoneDto> GetList(Expression<Func<dao.TimeZone, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<dao.TimeZone> daos = _repository.GetWhere(wherePredicate)
                                                        .OrderBy(a => a.TimeZoneInfoId)
                                                        .ToList();
            IEnumerable<TimeZoneDto> dtos = _mapper.GetDtosFromDaos(daos);

            return dtos;
        }

        public virtual IEnumerable<TimeZone_Summary> GetSummaryList(Expression<Func<dao.TimeZone, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<dao.TimeZone> list = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.TimeZoneInfoId);

            return _mapper.GetSummariesFromDaos(list);
        }

        #endregion

    }
}
