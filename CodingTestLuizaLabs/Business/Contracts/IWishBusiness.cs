using CodingTestLuizaLabs.Model;
using System.Collections.Generic;

namespace CodingTestLuizaLabs.Business
{
    public interface IWishBusiness : IBusiness<Wish>
    {
        void Delete(long userId, long productId);
        List<Product> FindWithPagedSearch(long userId, int pageSize, int page);
    }
}
