using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dna.NetCore.Core.BLL.Constants;
using Dna.NetCore.Core.BLL.Entities;
using Dna.NetCore.Core.Common;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class Country_Queries : ICountry_Queries
    {
        #region Private Fields

        private readonly ICountryRepository _repository;
        private readonly ICountryMapper _mapper;
        private readonly ISystemSetting_Queries _systemSettingQueries;

        #endregion

        #region ctor

        public Country_Queries(ICountryRepository repository,
                                ICountryMapper mapper,
                                ISystemSetting_Queries systemSettingQueries)
        {
            _repository = repository;
            _mapper = mapper;
            _systemSettingQueries = systemSettingQueries;
        }

        #endregion

        #region Query Methods

        public virtual CountryDto Get(Expression<Func<Country, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            Country dao = _repository.Get(wherePredicate);
            CountryDto dto = dao == null ? null : _mapper.GetDtoFromDao(dao);
            return dto;
        }

        public virtual CountryCmd GetCmd(string abbreviation)
        {
            if (string.IsNullOrEmpty(abbreviation))
                return null;

            CountryCmd cmd = null;

            Country dao = _repository.Get(a => a.Abbreviation == abbreviation);

            if (dao != null)
                cmd = _mapper.GetCmdFromDao(dao);
            
            return cmd;
        }

        public virtual CountryDto GetDefault()
        {
            CountryDto dto = null;

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

        public virtual IEnumerable<CountryDto> GetList(bool isActive = true, bool isDeleted = false)
        {
            return GetList(a => a.IsActive == isActive && a.IsDeleted == isDeleted);
        }

        public virtual IEnumerable<CountryDto> GetList(Expression<Func<Country, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<Country> daos = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.Abbreviation).ThenBy(a => a.DisplayName)
                                     .ToList();
            IEnumerable<CountryDto> dtos = _mapper.GetDtosFromDaos(daos);

            return dtos;
        }

        public virtual IEnumerable<CountrySummary> GetSummaryList(Expression<Func<Country, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<Country> list = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.Abbreviation).ThenBy(a => a.DisplayName);

            return _mapper.GetSummariesFromDaos(list);
        }

        public virtual IPagedList<CountrySummary> GetSummaryPagedList(Expression<Func<Country, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<Country> list = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.Abbreviation).ThenBy(a => a.DisplayName);
            IEnumerable<CountrySummary> summaries = _mapper.GetSummariesFromDaos(list);

            return new PagedList<CountrySummary>(summaries, pageIndex, pageSize);
        }

        public virtual bool HasAbbreviation(string name)
        {
            bool isFound = _repository.Get(a => a.Abbreviation == name) != null ? true : false;
            return isFound;
        }

        public virtual bool HasDisplayName(string name)
        {
            bool isFound = _repository.Get(a => a.DisplayName == name) != null ? true : false;
            return isFound;
        }

        #endregion
    }
}
