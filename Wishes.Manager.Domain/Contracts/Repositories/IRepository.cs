using CodingTestLuizaLabs.Model.Base;
using System.Collections.Generic;

namespace CodingTestLuizaLabs.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T entity);
        T Update(T entity);
        void Delete(long id);
        bool Exists(long? id);
        List<T> FindWithPagedSearch(string query);
    }
}
