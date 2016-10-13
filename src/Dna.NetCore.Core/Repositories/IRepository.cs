using Dna.NetCore.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dna.NetCore.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        #region Asynchronous CRUD Methods

        Task<int> AddAsync(T dao);
        //Task<int> RemoveAsync(int id);
        Task<int> SaveAsync();
        Task<int> UpdateAsync(T dao);

        //void SaveChangesAsync(out CustomMessage customMessage);

        #endregion

        #region Synchronous CRUD Methods

        T Add(T entity, out CustomMessage customMessage);
        T Create(out CustomMessage customMessage);
        T Remove(T entity, out CustomMessage customMessage);
        IEnumerable<T> Remove(Expression<Func<T, bool>> where, out CustomMessage customMessage);
        void Update(T entity, out CustomMessage customMessage);

        int SaveChanges(out CustomMessage customMessage);

        #endregion

        #region Queries

        T Get(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> where);

        #endregion
    }
}
