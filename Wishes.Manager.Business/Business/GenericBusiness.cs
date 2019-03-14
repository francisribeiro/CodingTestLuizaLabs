using CodingTestLuizaLabs.Model.Base;
using CodingTestLuizaLabs.Repository.Generic;

namespace CodingTestLuizaLabs.Business.Implementations
{
    public class GenericBusiness<T> : IBusiness<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public GenericBusiness(IRepository<T> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Create a generic entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity created</returns>
        public T Create(T entity)
        {
            return _repository.Create(entity);
        }

        /// <summary>
        /// Update a generic entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity updated</returns>
        public T Update(T entity)
        {
            return _repository.Update(entity);
        }

        /// <summary>
        /// Delete a generic entity
        /// </summary>
        /// <param name="id">Id</param>
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
