using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class City_Queries : ICity_Queries
    {
        #region Private Fields

        private readonly ICityRepository _repository;
        private readonly ICityMapper _mapper;

        #endregion

        #region ctor

        public City_Queries(ICityRepository repository,
                                    ICityMapper mapper
                                    )
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Query Methods

        public virtual CityDto Get(int id)
        {
            if (id < 1) return null;
            City dao = _repository.Get(a => a.Id == id);
            CityDto model = dao == null ? null : _mapper.GetDtoFromDao(dao);
            return model;
        }

        public virtual CityDto Get(Expression<Func<City, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            City dao = _repository.Get(wherePredicate);
            CityDto dto = dao == null ? null : _mapper.GetDtoFromDao(dao);
            return dto;
        }

        public virtual CityCmd GetCmd(int id)
        {
            if (id < 1) return null;
            City dao = _repository.Get(a => a.Id == id);
            CityCmd cmd = dao == null ? null : _mapper.GetCmdFromDao(dao);
            return cmd;
        }

        public virtual IEnumerable<CityDto> GetList(Expression<Func<City, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<City> daos = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.DisplayName)
                                     .ToList();
            IEnumerable<CityDto> dtos = _mapper.GetDtosFromDaos(daos);
            return dtos;
        }

        public virtual IEnumerable<CitySummary> GetSummaryList(Expression<Func<City, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<City> list = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.DisplayName);
            return _mapper.GetSummariesFromDaos(list);
        }

        public virtual IPagedList<CitySummary> GetSummaryPagedList(Expression<Func<City, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<City> list = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.DisplayName);
            IEnumerable<CitySummary> summaries = _mapper.GetSummariesFromDaos(list);
            return new PagedList<CitySummary>(summaries, pageIndex, pageSize);
        }

        public virtual bool HasDisplayName(string name)
        {
            bool isFound = _repository.Get(a => a.DisplayName == name) != null ? true : false;
            return isFound;
        }

        #endregion
    }
}
