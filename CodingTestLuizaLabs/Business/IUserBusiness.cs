using CodingTestLuizaLabs.Model;
using System.Collections.Generic;

namespace CodingTestLuizaLabs.Business
{
    public interface IUserBusiness : IBusiness<User>
    {
        List<User> FindWithPagedSearch(int pageSize, int page);
    }
}
