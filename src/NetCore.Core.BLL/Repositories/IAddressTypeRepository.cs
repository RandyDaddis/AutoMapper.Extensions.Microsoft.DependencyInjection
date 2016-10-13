using NetCore.Core.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NetCore.Core.BLL.Repositories.Common
{
    public interface IAddressTypeRepository
    {
        #region Synchronous CRUD Methods

        AddressType Add(AddressType entity);
        AddressType Create();
        AddressType Remove(AddressType entity);
        IEnumerable<AddressType> Remove(Expression<Func<AddressType, bool>> where);
        void Update(AddressType entity);

        int SaveChanges();

        #endregion

        #region Queries

        AddressType Get(Expression<Func<AddressType, bool>> where);
        IQueryable<AddressType> GetAll();
        IQueryable<AddressType> GetWhere(Expression<Func<AddressType, bool>> where);

        #endregion
    }
}
