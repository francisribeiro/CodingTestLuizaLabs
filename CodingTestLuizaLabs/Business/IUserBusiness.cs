using CodingTestLuizaLabs.Model;
using Tapioca.HATEOAS.Utils;

namespace CodingTestLuizaLabs.Business
{
    public interface IUserBusiness : IBusiness<User>
    {
        PagedSearchDTO<User> FindWithPagedSearch(int pageSize, int page);
    }
}
