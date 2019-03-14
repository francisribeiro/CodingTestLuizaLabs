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

        /// <summary>
        /// Brings a list of products based on a paged query
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="page">Page</param>
        /// <returns>List of products</returns>
        public List<Product> FindWithPagedSearch(int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;

            string query = @"SELECT * FROM Products p WHERE 1 = 1";
            query = query + $" ORDER BY p.Name ASC OFFSET({page}) * {pageSize}";
            query = query + $" ROWS FETCH NEXT {pageSize} ROWS ONLY";

            return _repository.FindWithPagedSearch(query);
        }
    }
}
