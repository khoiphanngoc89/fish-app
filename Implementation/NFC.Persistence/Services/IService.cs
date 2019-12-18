using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Persistence.Services
{
    public interface IService<TKey, TModel>
        where TKey: IComparable
        where TModel: class
    {
        TKey Add(TModel model);

        IEnumerable<TModel> GetAll();

        IEnumerable<TModel> GetAllPaging(int pageNumber = 1, int pageSize = 30, bool getLastest = false);

        TModel GetById(TKey key);

        void Update(TKey key, TModel model);

        void Delete(TKey key);
    }
}
