using CodingTestLuizaLabs.Model;
using System.Collections.Generic;

namespace CodingTestLuizaLabs.Business
{
    public interface IProductBusiness : IBusiness<Product>
    {
        List<Product> FindWithPagedSearch(int pageSize, int page);
    }
}
