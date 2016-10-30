using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class PersonType_Queries : IPersonType_Queries
    {
        #region Private Fields

        private readonly IPersonTypeRepository _repository;

        #endregion

        #region ctor

        public PersonType_Queries(IPersonTypeRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Query Methods

        public virtual PersonType Get(int id)
        {
            if (id < 1) return null;
            PersonType dao = _repository.Get(a => a.Id == id);
            return dao;
        }

        public virtual PersonType Get(Expression<Func<PersonType, bool>> wherePredicate)
        {
            PersonType dao = _repository.Get(wherePredicate);
            return dao;
        }

        public virtual IQueryable<PersonType> GetList(Expression<Func<PersonType, bool>> wherePredicate)
        {
            IQueryable<PersonType> daos = _repository.GetWhere(wherePredicate);
                                                     //.OrderBy(a => a.DisplayName);
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
