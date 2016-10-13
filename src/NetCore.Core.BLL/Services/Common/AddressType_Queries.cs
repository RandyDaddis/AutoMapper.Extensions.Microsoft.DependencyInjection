using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.BLL.Mappers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class AddressType_Queries : IAddressType_Queries
    {
        #region Private Fields

        private readonly IAddressTypeRepository _repository;
        private readonly IAddressTypeMapper _mapper;

        #endregion

        #region ctor

        //public delegate AddressType_Queries Factory();

        //public AddressType_Queries()
        //{
        //    _repository = Ioc.Resolve<IAddressTypeRepository>();
        //    if (_repository == null)
        //        throw new Exception("AddressType_Queries() - unable to resolve Ioc.Resolve<IAddressTypeRepository>()");

        //    _mapper = Ioc.Resolve<IAddressTypeMapper>();
        //    if (_mapper == null)
        //        throw new Exception("AddressType_Queries() - unable to resolve Ioc.Resolve<IAddressTypeMapper>()");

        //}

        public AddressType_Queries(IAddressTypeRepository repository,
                                    IAddressTypeMapper mapper
                                    )
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region Query Methods

        public virtual AddressTypeDto Get(int id)
        {
            if (id < 1)
                return null;

            AddressType dao = _repository.Get(a => a.Id == id);
            AddressTypeDto model = dao == null ? null : _mapper.GetDtoFromDao(dao);
            return model;
        }

        public virtual AddressTypeDto Get(Expression<Func<AddressType, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            AddressType dao = _repository.Get(wherePredicate);
            AddressTypeDto dto = dao == null ? null : _mapper.GetDtoFromDao(dao);
            return dto;
        }

        public virtual AddressTypeCmd GetCmd(int id)
        {
            if (id < 1)
                return null;

            AddressType dao = _repository.Get(a => a.Id == id);
            AddressTypeCmd cmd = dao == null ? null : _mapper.GetCmdFromDao(dao);
            return cmd;
        }

        public virtual IEnumerable<AddressTypeDto> GetList(Expression<Func<AddressType, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<AddressType> daos = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.DisplayName)
                                     .ToList();
            IEnumerable<AddressTypeDto> dtos = _mapper.GetDtosFromDaos(daos);
            return dtos;
        }

        public virtual IEnumerable<AddressTypeSummary> GetSummaryList(Expression<Func<AddressType, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<AddressType> list = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.DisplayName);
            return _mapper.GetSummariesFromDaos(list);
        }

        public virtual IPagedList<AddressTypeSummary> GetSummaryPagedList(Expression<Func<AddressType, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10)
        {
            if (wherePredicate == null)
                return null;

            IEnumerable<AddressType> list = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.DisplayName);
            IEnumerable<AddressTypeSummary> summaries = _mapper.GetSummariesFromDaos(list);
            return new PagedList<AddressTypeSummary>(summaries, pageIndex, pageSize);
        }

        public virtual bool HasDisplayName(string displayName)
        {
            if (string.IsNullOrEmpty(displayName))
                return false;

            bool isFound = _repository.Get(a => a.DisplayName == displayName) != null ? true : false;
            return isFound;
        }

        public virtual bool HasSystemName(string systemName)
        {
            if (string.IsNullOrEmpty(systemName))
                return false;

            bool isFound = _repository.Get(a => a.SystemName == systemName) != null ? true : false;
            return isFound;
        }

        #endregion
    }
}
