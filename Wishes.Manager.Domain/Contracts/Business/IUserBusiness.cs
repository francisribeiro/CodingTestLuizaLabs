using CodingTestLuizaLabs.Model;
using System.Collections.Generic;

namespace CodingTestLuizaLabs.Business
{
    public interface IUserBusiness : IBusiness<User>
    {
        new User Create(User user);
        bool Exists(string email);
        List<User> FindWithPagedSearch(int pageSize, int page);
    }
}
