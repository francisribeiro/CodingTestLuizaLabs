using CodingTestLuizaLabs.Model.Base;
using System.Collections.Generic;

namespace CodingTestLuizaLabs.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        T FindById(long id);
        void Delete(long id);
        bool Exists(long? id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
