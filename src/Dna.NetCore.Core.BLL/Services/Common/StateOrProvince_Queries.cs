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
    public partial class StateOrProvince_Queries : IStateOrProvince_Queries
    {
        #region Private Fields

        private readonly IStateOrProvinceRepository _repository;
        private readonly IStateOrProvinceMapper _mapper;
        private readonly ISystemSetting_Queries _systemSettingQueries;

        #endregion

        #region ctor

        public StateOrProvince_Queries(IStateOrProvinceRepository repository,
                                        IStateOrProvinceMapper mapper,
                                        ISystemSetting_Queries systemSettingQueries)
        {
            _repository = repository;
            _mapper = mapper;
            _systemSettingQueries = systemSettingQueries;
        }

        #endregion

        #region Query Methods

        public virtual StateOrProvinceDto Get(Expression<Func<StateOrProvince, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            StateOrProvince dao = _repository.Get(wherePredicate);

            StateOrProvinceDto dto = dao == null ? null : _mapper.GetDtoFromDao(dao);

            return dto;
        }

        public virtual StateOrProvinceCmd GetCmd(int id)
        {
            if (id < 1) 
                return null;

            StateOrProvince dao = _repository.Get(a => a.Id == id);

            StateOrProvinceCmd cmd = dao == null ? null : _mapper.GetCmdFromDao(dao);

            return cmd;
        }

        public virtual StateOrProvinceDto GetDefault()
        {
            StateOrProvinceDto dto = null;

            string defaultAbbreviation = GetDefaultAbbreviation();

            if (!string.IsNullOrEmpty(defaultAbbreviation))
                dto = this.Get(a => a.Abbreviation == defaultAbbreviation);

            return dto;
        }
        public virtual string GetDefaultAbbreviation()
        {
            string abbreviation = "";

            SystemSetting systemSetting = _systemSettingQueries.Get(j => j.SystemName == SystemSettingConstants.Core_CountryAbbreviation);

            if (systemSetting != null)
                abbreviation = systemSetting.StringValue;

            return abbreviation;
        }

        public virtual IEnumerable<StateOrProvinceDto> GetList(bool isActive = true, bool isDeleted = false)
        {
            return GetList(a => a.IsActive == isActive && a.IsDeleted == isDeleted);
        }

        public virtual IEnumerable<StateOrProvinceDto> GetList(Expression<Func<StateOrProvince, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<StateOrProvince> daos = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.Abbreviation)
                                     .ToList();
            IEnumerable<StateOrProvinceDto> dtos = _mapper.GetDtosFromDaos(daos);

            return dtos;
        }

        public virtual IEnumerable<StateOrProvince_Summary> GetSummaryList(Expression<Func<StateOrProvince, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<StateOrProvince> list = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.Abbreviation);

            return _mapper.GetSummariesFromDaos(list);
        }

        public virtual IPagedList<StateOrProvince_Summary> GetSummaryPagedList(Expression<Func<StateOrProvince, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<StateOrProvince> list = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.Abbreviation);

            IEnumerable<StateOrProvince_Summary> summaries = _mapper.GetSummariesFromDaos(list);

            return new PagedList<StateOrProvince_Summary>(summaries, pageIndex, pageSize);
        }

        public virtual bool HasAbbreviation(string name)
        {
            bool isFound = _repository.Get(a => a.Abbreviation == name) != null ? true : false;

            return isFound;
        }

        public virtual bool HasName(string name)
        {
            bool isFound = _repository.Get(a => a.DisplayName == name) != null ? true : false;

            return isFound;
        }

        #endregion
    }
}
