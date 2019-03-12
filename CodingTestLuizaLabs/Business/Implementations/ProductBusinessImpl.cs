using CodingTestLuizaLabs.Model;
using CodingTestLuizaLabs.Repository.Generic;
using System.Collections.Generic;

namespace CodingTestLuizaLabs.Business.Implementations
{
    public class ProductBusinessImpl : GenericBusiness<Product>, IProductBusiness
    {
        private readonly IRepository<Product> _repository;

        public ProductBusinessImpl(IRepository<Product> repository) : base(repository)
        {
            _repository = repository;
        }

        public List<Product> FindWithPagedSearch(int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;

            string query = @"SELECT * FROM Products p WHERE 1 = 1";
            query = query + $" ORDER BY p.Name DESC OFFSET({page}) * {pageSize}";
            query = query + $" ROWS FETCH NEXT {pageSize} ROWS ONLY";

            return _repository.FindWithPagedSearch(query);
        }
    }
}
