using CodingTestLuizaLabs.Model;
using Tapioca.HATEOAS.Utils;

namespace CodingTestLuizaLabs.Business
{
    public interface IUserBusiness
    {
        User Create(User user);
        User FindById(long id);
        User Update(User user);
        void Delete(long id);
        bool Exists(long id);
        PagedSearchDTO<User> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
