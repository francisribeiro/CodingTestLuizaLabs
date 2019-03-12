using CodingTestLuizaLabs.Model;
using Tapioca.HATEOAS.Utils;

namespace CodingTestLuizaLabs.Business
{
    public interface IProductBusiness : IBusiness<Product>
    {
        PagedSearchDTO<Product> FindWithPagedSearch(int pageSize, int page);
    }
}
