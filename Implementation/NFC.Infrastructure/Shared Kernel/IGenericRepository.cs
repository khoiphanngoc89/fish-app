using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NFC.Infrastructure.SharedKernel
{
    /// <summary>
    /// Provides shared data access object methods.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGenericRepository<TKey, TEntity>
        where TKey : IComparable
        where TEntity : class
    {
        /// <summary>
        /// Gets the single by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        TEntity GetSingleById(TKey id);

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        TKey Add(TEntity model);

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        void Update(TKey id, TEntity model);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Finds by condition.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, object>> expression);

        /// <summary>
        /// Finds by condition.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        IEnumerable<T> Find<T>(Expression<Func<T, object>> expression) where T : class;

        /// <summary>
        /// Gets all by paging.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="getLatest">if set to <c>true</c> [get latest].</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllByPaging(int pageNumber = 1, int pageSize = 30, bool getLatest = false);

        /// <summary>
        /// Gets all by paging.
        /// </summary>
        /// <param name="storeName">Name of the store.</param>
        /// <param name="name">The name.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="getLatest">if set to <c>true</c> [get latest].</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllByPaging(string storeName, int pageNumber = 1, int pageSize = 30, bool getLatest = false);

        /// <summary>
        /// Gets all by paging.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeName">Name of the store.</param>
        /// <param name="name">The name.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="getLatest">if set to <c>true</c> [get latest].</param>
        /// <returns></returns>
        IEnumerable<T> GetAllByPaging<T>(string storeName, int pageNumber = 1, int pageSize = 30, bool getLatest = false) where T : class;

        /// <summary>
        /// Gets the by by paging search.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="getLatest">if set to <c>true</c> [get latest].</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetByByPagingSearch(string name, int pageNumber = 1, int pageSize = 30, bool getLatest = false);

        /// <summary>
        /// Gets the by by paging search.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeName">Name of the store.</param>
        /// <param name="name">The name.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="getLatest">if set to <c>true</c> [get latest].</param>
        /// <returns></returns>
        IEnumerable<T> GetByByPagingSearch<T>(string storeName, string name, int pageNumber = 1, int pageSize = 30, bool getLatest = false) where T: class;

        /// <summary>
        /// Remove an instance.
        /// </summary>
        /// <param name="key">The key.</param>
        void Remove(TKey key);

        /// <summary>
        /// Selects the single or default.
        /// </summary>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="parmas">The parmas.</param>
        /// <returns></returns>
        TEntity SelectSingleOrDefault(string storedName, IDictionary<string, object> parmas = null);

        /// <summary>
        /// Selects the single or default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="parmas">The parmas.</param>
        /// <returns></returns>
        T SelectSingleOrDefault<T>(string storedName, IDictionary<string, object> parmas = null) where T : class;

        /// <summary>
        /// Selects the specified instances.
        /// </summary>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="parmas">The parmas.</param>
        /// <returns></returns>
        IEnumerable<TEntity> Select(string storedName, IDictionary<string, object> parmas = null);

        /// <summary>
        /// Selects the specified instances.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="parmas">The parmas.</param>
        /// <returns></returns>
        IEnumerable<T> Select<T>(string storedName, IDictionary<string, object> parmas = null) where T : class;

        /// <summary>
        /// Executes the specified stored procedure.
        /// </summary>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="parmas">The parmas.</param>
        /// <returns></returns>
        IEnumerable<TEntity> Execute(string storedName, IDictionary<string, object> parmas = null);

        /// <summary>
        /// Executes the specified stored procedure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="parmas">The parmas.</param>
        /// <returns></returns>
        IEnumerable<T> Execute<T>(string storedName, IDictionary<string, object> parmas = null) where T : class;

    }

    /// <summary>
    /// Provides data access object wrapper dapper.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Selects the single or default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="parmas">The parmas.</param>
        /// <returns></returns>
        T SelectSingleOrDefault<T>(string storedName, IDictionary<string, object> parmas);

        /// <summary>
        /// Selects the specified stored name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="parmas">The parmas.</param>
        /// <returns></returns>
        IEnumerable<T> Select<T>(string storedName, IDictionary<string, object> parmas);


        /// <summary>
        /// Selects the specified stored name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="parmas">The parmas.</param>
        /// <returns></returns>
        IEnumerable<T> Select<T>(string storedName);

        /// <summary>
        /// Executes the specified stored name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedName">Name of the stored.</param>
        /// <param name="parmas">The parmas.</param>
        /// <returns></returns>
        IEnumerable<T> Execute<T>(string storedName, IDictionary<string, object> parmas);

        /// <summary>
        /// Queries the sql.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The sql.</param>
        /// <returns></returns>
        IEnumerable<T> Query<T>(string sql);
    }
}
