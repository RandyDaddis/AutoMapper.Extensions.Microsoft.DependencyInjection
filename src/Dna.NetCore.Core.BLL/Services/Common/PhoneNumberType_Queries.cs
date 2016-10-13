using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class PhoneNumberType_Queries : IPhoneNumberType_Queries
    {
        #region Private Fields

        private readonly IPhoneNumberTypeRepository _repository;

        #endregion

        #region ctor

        //public delegate PhoneNumberType_Queries Factory();

        //public PhoneNumberType_Queries()
        //{
        //    _repository = Ioc.Resolve<IPhoneNumberTypeRepository>();
        //    if (_repository == null)
        //        throw new Exception("PhoneNumberType_Queries() - unable to resolve Ioc.Resolve<IPhoneNumberTypeRepository>()");

        //}

        public PhoneNumberType_Queries(IPhoneNumberTypeRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Query Methods

        public virtual PhoneNumberType Get(int id)
        {
            if (id < 1) return null;
            PhoneNumberType dao = _repository.Get(a => a.Id == id);
            return dao;
        }

        public virtual PhoneNumberType Get(Expression<Func<PhoneNumberType, bool>> wherePredicate)
        {
            PhoneNumberType dao = _repository.Get(wherePredicate);
            return dao;
        }

        public virtual IQueryable<PhoneNumberType> GetList(Expression<Func<PhoneNumberType, bool>> wherePredicate)
        {
            IQueryable<PhoneNumberType> daos = _repository.GetWhere(wherePredicate)
                                     .OrderBy(a => a.DisplayName);
            return daos;
        }

        public virtual bool HasSystemName(string systemName)
        {
            bool isFound = _repository.Get(a => a.SystemName == systemName) != null ? true : false;
            return isFound;
        }

        #endregion
    }
}
