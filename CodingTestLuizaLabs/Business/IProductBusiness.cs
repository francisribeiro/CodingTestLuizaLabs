using CodingTestLuizaLabs.Model;
using Tapioca.HATEOAS.Utils;

namespace CodingTestLuizaLabs.Business
{
    public interface IProductBusiness
    {
        Product Create(Product product);
        Product FindById(long id);
        Product Update(Product product);
        void Delete(long id);
        bool Exists(long id);
        PagedSearchDTO<Product> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
