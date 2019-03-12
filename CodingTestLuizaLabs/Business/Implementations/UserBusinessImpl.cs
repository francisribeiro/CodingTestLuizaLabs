using CodingTestLuizaLabs.Model;
using CodingTestLuizaLabs.Repository.Generic;
using Tapioca.HATEOAS.Utils;

namespace CodingTestLuizaLabs.Business.Implementations
{
    public class UserBusinessImpl : GenericBusiness<User>, IUserBusiness
    {
        public UserBusinessImpl(IRepository<User> repository) : base(repository) { }

        public PagedSearchDTO<User> FindWithPagedSearch(int pageSize, int page)
        {
            throw new System.NotImplementedException();
        }
    }
}
