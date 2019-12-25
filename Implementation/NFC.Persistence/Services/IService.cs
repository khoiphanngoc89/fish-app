using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Persistence.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public interface IService<TKey, TModel>
        where TKey: IComparable
        where TModel: class
    {
        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        TKey Add(TModel model);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TModel> GetAll();

        /// <summary>
        /// Gets all paging.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="getLatest">if set to <c>true</c> [get lastest].</param>
        /// <returns></returns>
        IEnumerable<TModel> GetAllPaging(int pageNumber = 1, int pageSize = 30, bool getLatest = false);

        /// <summary>
        /// Gets all paging search.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="getLatest">if set to <c>true</c> [get latest].</param>
        /// <returns></returns>
        IEnumerable<TModel> GetAllPagingSearch(string name, int pageNumber = 1, int pageSize = 30, bool getLatest = false);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        TModel GetById(TKey key);

        /// <summary>
        /// Updates the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="model">The model.</param>
        void Update(TKey key, TModel model);

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        void Delete(TKey key);
    }
}
