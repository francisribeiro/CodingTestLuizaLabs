using CodingTestLuizaLabs.Model;
using CodingTestLuizaLabs.Repository.Generic;
using Tapioca.HATEOAS.Utils;

namespace CodingTestLuizaLabs.Business.Implementations
{
    public class ProductBusinessImpl : GenericBusiness<Product>, IProductBusiness
    {
        public ProductBusinessImpl(IRepository<Product> repository) : base(repository) { }

        public PagedSearchDTO<Product> FindWithPagedSearch(int pageSize, int page)
        {
            throw new System.NotImplementedException();
        }
    }
}
