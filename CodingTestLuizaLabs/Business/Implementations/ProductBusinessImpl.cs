using CodingTestLuizaLabs.Model;
using CodingTestLuizaLabs.Repository.Generic;
using Tapioca.HATEOAS.Utils;

namespace CodingTestLuizaLabs.Business.Implementations
{
    public class ProductBusinessImpl : IProductBusiness
    {
        private IRepository<Product> _repository;

        public ProductBusinessImpl(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public Product Create(Product product)
        {
            return _repository.Create(product);
        }

        public Product FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Product Update(Product product)
        {
            return _repository.Update(product);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PagedSearchDTO<Product> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(long id)
        {
            return _repository.Exists(id);
        }
    }
}
