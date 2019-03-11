using CodingTestLuizaLabs.Model;
using CodingTestLuizaLabs.Repository.Generic;
using Tapioca.HATEOAS.Utils;

namespace CodingTestLuizaLabs.Business.Implementations
{
    public class UserBusinessImpl : IUserBusiness
    {
        private IRepository<User> _repository;

        public UserBusinessImpl(IRepository<User> repository)
        {
            _repository = repository;
        }

        public User Create(User user)
        {
            return _repository.Create(user);
        }

        public User FindById(long id)
        {
            return _repository.FindById(id);
        }

        public User Update(User user)
        {
            return _repository.Update(user);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PagedSearchDTO<User> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(long id)
        {
            return _repository.Exists(id);
        }
    }
}
