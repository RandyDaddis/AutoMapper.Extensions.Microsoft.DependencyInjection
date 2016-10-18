using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dna.NetCore.Core.DAL.EFCore.Repositories
{
    public abstract class RepositoryBase<T, U>
        where T : class
        where U : DbContext, new()
    {
        #region Private Fields

        private U _dataContext;
        //private readonly IDbSet<T> _dbset;  // IDbSet not implemented in .NET Core 1.0.1
        private readonly Microsoft.EntityFrameworkCore.DbSet<T> _dbset;

        #endregion

        #region ctor

        protected RepositoryBase(IDatabaseFactory<U> databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbset = DataContext.Set<T>();
        }

        #endregion

        #region Protected Properties

        protected IDatabaseFactory<U> DatabaseFactory
        {
            get;
            private set;
        }

        protected U DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }

        #endregion

        #region Synchronous CRUD Methods

        public virtual T Add(T entity, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            object dao = null;

            try
            {
                dao = _dbset.Add(entity);
            }
            catch (SqlException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (InvalidOperationException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (ArgumentException exception)
            {
                customMessage1 = exception.Handle();
            }

            // DEVNOTE: exceptions are logged at the exception handler and the controller levels

            customMessage = customMessage1;

            return dao as T;
        }

        // Not implemented in EF Core 1.0.1
        //public virtual T Create(out CustomMessage customMessage)
        //{
        //    CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
        //    object dao = null;
        //    try
        //    {
        //        dao = _dbset.Create();
        //    }
        //    catch (SqlException exception)
        //    {
        //        customMessage1 = exception.Handle();
        //    }
        //    catch (InvalidOperationException exception)
        //    {
        //        customMessage1 = exception.Handle();
        //    }
        //    catch (ArgumentException exception)
        //    {
        //        customMessage1 = exception.Handle();
        //    }
        //    customMessage = customMessage1;
        //    return dao as T;
        //}

        public virtual IEnumerable<T> Delete(Expression<Func<T, bool>> where, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            IEnumerable<object> objects = null;

            try
            {
                objects = _dbset.Where<T>(where).AsEnumerable();
                foreach (T obj in objects)
                    _dbset.Remove(obj);
            }
            catch (SqlException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (InvalidOperationException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (ArgumentException exception)
            {
                customMessage1 = exception.Handle();
            }
            customMessage = customMessage1;
            return objects as IEnumerable<T>;
        }

        /// <summary>
        /// 
        ///     Marks the given entity as Deleted such that it will be deleted from the database
        ///     when SaveChanges is called. Note that the entity must exist in the context
        ///     in some other state before this method is called.
        /// </summary>
        /// <remarks>
        ///     Note that if the entity exists in the context in the Added state, then this
        ///     method will cause it to be detached from the context. This is because an
        ///     Added entity is assumed not to exist in the database such that trying to
        ///     delete it does not make sense.
        /// </remarks>
        public virtual T Remove(T entity, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            EntityEntry<T> dao = null;
            try
            {
                dao = _dbset.Attach(entity);
                dao = _dbset.Remove(entity);
            }
            catch (SqlException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (InvalidOperationException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (ArgumentException exception)
            {
                customMessage1 = exception.Handle();
            }
            customMessage = customMessage1;
            return dao as T;
        }

        public virtual IEnumerable<T> Remove(Expression<Func<T, bool>> where, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            IEnumerable<object> objects = null;
            try
            {
                objects = _dbset.Where<T>(where).AsEnumerable();
                foreach (T obj in objects)
                {
                    _dbset.Attach(obj);
                    _dbset.Remove(obj);
                }
            }
            catch (SqlException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (InvalidOperationException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (ArgumentException exception)
            {
                customMessage1 = exception.Handle();
            }
            customMessage = customMessage1;
            return objects as IEnumerable<T>;
        }

        public virtual void Update(T entity, out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            try
            {
                _dbset.Attach(entity);
                _dataContext.Entry(entity).State = EntityState.Modified;
            }
            catch (SqlException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (InvalidOperationException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (ArgumentException exception)
            {
                customMessage1 = exception.Handle();
            }
            customMessage = customMessage1;
            return;
        }


        /// <summary>
        ///     Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <param name="out customMessage"></param>
        /// <returns>
        ///     The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateException">
        ///     An error occurred sending updates to the database.
        /// </exception>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateConcurrencyException">
        ///     A database command did not affect the expected number of rows. This usually
        ///     indicates an optimistic concurrency violation; that is, a row has been changed
        ///     in the database since it was queried.
        /// </exception>
        /// <exception cref="System.Data.Entity.Validation.DbEntityValidationException">
        ///     The save was aborted because validation of entity property values failed.
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        ///     An attempt was made to use unsupported behavior such as executing multiple
        ///     asynchronous commands concurrently on the same context instance.
        /// </exception>
        /// <exception cref="System.ObjectDisposedException">
        ///     The context or connection have been disposed.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        ///     Some error occurred attempting to process entities in the context either
        ///     before or after sending commands to the database.
        /// </exception>
        // TODO: refactor Exceptions after .NET Core 1.1 is published
        public virtual int SaveChanges(out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            int numberOfChanges = 0;

            try
            {
                numberOfChanges = _dataContext.SaveChanges();
            }
            catch (SqlException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (InvalidOperationException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (ArgumentException exception)
            {
                customMessage1 = exception.Handle();
            }
            customMessage = customMessage1;
            return numberOfChanges;
        }

        #endregion

        #region Asynchronous CRUD Methods

        public virtual async Task<int> AddAsync(T dao)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            try
            {
                _dbset.Add(dao);
                return await _dataContext.SaveChangesAsync();
            }
            catch (SqlException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (InvalidOperationException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (ArgumentException exception)
            {
                customMessage1 = exception.Handle();
            }
            return 0;
        }

        //public virtual async Task<int> RemoveAsync(int id)
        //{
        //    CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
        //    try
        //    {
        //        T dao = _dbset.Find(id);  // .Find will be published in .NET Core 1.1
        //        if ((T)dao != null)
        //            _dbset.Remove(dao);
        //        return await _dataContext.SaveChangesAsync();
        //    }
        //    catch (SqlException exception)
        //    {
        //        customMessage1 = exception.Handle();
        //    }
        //    catch (InvalidOperationException exception)
        //    {
        //        customMessage1 = exception.Handle();
        //    }
        //    catch (ArgumentException exception)
        //    {
        //        customMessage1 = exception.Handle();
        //    }
        //    return 0;
        //}

        public virtual async Task<int> UpdateAsync(T dao)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            try
            {
                _dbset.Attach(dao);
                _dataContext.Entry(dao).State = EntityState.Modified;
                return await _dataContext.SaveChangesAsync();
            }
            catch (SqlException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (InvalidOperationException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (ArgumentException exception)
            {
                customMessage1 = exception.Handle();
            }
            return 0;
        }

        /// <summary>
        ///     Asynchronously saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        ///     A task that represents the asynchronous save operation.  The task result
        ///     contains the number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateException">
        ///     An error occurred sending updates to the database.
        /// </exception>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateConcurrencyException">
        ///     A database command did not affect the expected number of rows. This usually
        ///     indicates an optimistic concurrency violation; that is, a row has been changed
        ///     in the database since it was queried.
        /// </exception>
        /// <exception cref="System.Data.Entity.Validation.DbEntityValidationException">
        ///     The save was aborted because validation of entity property values failed.
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        ///     An attempt was made to use unsupported behavior such as executing multiple
        ///     asynchronous commands concurrently on the same context instance.
        /// </exception>
        /// <exception cref="System.ObjectDisposedException">
        ///     The context or connection have been disposed.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        ///     Some error occurred attempting to process entities in the context either
        ///     before or after sending commands to the database.
        /// </exception>
        /// <remarks>
        ///     Multiple active operations on the same context instance are not supported.
        ///     Use 'await' to ensure that any asynchronous operations have completed before
        ///     calling another method on this context.        
        /// </remarks>
        // TODO: refactor exception notes after implementing .NET Core 1.1
        public virtual async Task<int> SaveAsync()
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            try
            {
                return await _dataContext.SaveChangesAsync();
            }
            catch (SqlException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (InvalidOperationException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (ArgumentException exception)
            {
                customMessage1 = exception.Handle();
            }
            return 0;
        }

        #endregion

        #region Queries

        public virtual IQueryable<T> GetAll()
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            IQueryable<object> dao = null;
            try
            {
                dao = _dbset;
            }
            catch (SqlException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (InvalidOperationException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (ArgumentException exception)
            {
                customMessage1 = exception.Handle();
            }
            return dao as IQueryable<T>;
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            object dao = null;
            try
            {
                dao = _dbset.Where(where).FirstOrDefault<T>();
            }
            catch (SqlException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (InvalidOperationException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (ArgumentException exception)
            {
                customMessage1 = exception.Handle();
            }
            return dao as T;
        }

        public virtual IQueryable<T> GetWhere(Expression<Func<T, bool>> where)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            IQueryable<object> dao = null;
            try
            {
                dao = _dbset.Where(where);
            }
            catch (SqlException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (InvalidOperationException exception)
            {
                customMessage1 = exception.Handle();
            }
            catch (ArgumentException exception)
            {
                customMessage1 = exception.Handle();
            }
            return dao as IQueryable<T>;
        }

        #endregion
    }
}
