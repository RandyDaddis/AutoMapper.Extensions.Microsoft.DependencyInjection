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
    public partial class County_Queries : ICounty_Queries
    {
        #region Private Fields

        private readonly ICountyRepository _repository;
        private readonly ICountyMapper _mapper;

        #endregion

        #region ctor

        public County_Queries(ICountyRepository repository,
                                    ICountyMapper mapper
                                    )
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Query Methods

        public virtual CountyDto Get(int id)
        {
            if (id < 1)
                return null;

            County dao = _repository.Get(a => a.Id == id);
            CountyDto model = dao == null ? null : _mapper.GetDtoFromDao(dao);

            return model;
        }

        public virtual CountyDto Get(Expression<Func<County, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            County dao = _repository.Get(wherePredicate);
            CountyDto dto = dao == null ? null : _mapper.GetDtoFromDao(dao);

            return dto;
        }

        public virtual CountyCmd GetCmd(int id)
        {
            if (id < 1) return null;
            County dao = _repository.Get(a => a.Id == id);
            CountyCmd cmd = dao == null ? null : _mapper.GetCmdFromDao(dao);
            return cmd;
        }

        public virtual IEnumerable<CountyDto> GetList(Expression<Func<County, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<County> daos = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.DisplayName)
                                     .ToList();
            IEnumerable<CountyDto> dtos = _mapper.GetDtosFromDaos(daos);

            return dtos;
        }

        public virtual IEnumerable<CountySummary> GetSummaryList(Expression<Func<County, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<County> list = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.DisplayName);

            return _mapper.GetSummariesFromDaos(list);
        }

        public virtual IPagedList<CountySummary> GetSummaryPagedList(Expression<Func<County, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<County> list = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.DisplayName);

            IEnumerable<CountySummary> summaries = _mapper.GetSummariesFromDaos(list);

            return new PagedList<CountySummary>(summaries, pageIndex, pageSize);
        }

        public virtual bool HasDisplayName(string name)
        {
            bool isFound = _repository.Get(a => a.DisplayName == name) != null ? true : false;
            return isFound;
        }

        #endregion
    }
}
