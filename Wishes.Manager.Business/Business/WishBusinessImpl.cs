using CodingTestLuizaLabs.Model;
using CodingTestLuizaLabs.Repository.Generic;
using System.Collections.Generic;

namespace CodingTestLuizaLabs.Business.Implementations
{
    public class WishBusinessImpl : GenericBusiness<Wish>, IWishBusiness
    {
        private readonly IRepository<Wish> _repository;
        private readonly IRepository<Product> _productRepository;
        private readonly IWishRepository _wishRepository;

        public WishBusinessImpl(IRepository<Wish> repository, IRepository<Product> productRepository, IWishRepository wishRepository) : base(repository)
        {
            _repository = repository;
            _productRepository = productRepository;
            _wishRepository = wishRepository;
        }

        /// <summary>
        /// Create a new wish list
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="wishList">List of whishes</param>
        /// <returns>Wish list created</returns>
        public Wish[] Create(long userId, Wish[] wishList)
        {
            foreach (Wish wish in wishList)
            {
                if (!Exists(userId, wish.IdProduct))
                {
                    wish.SetUserId(userId);
                    _wishRepository.Create(wish);
                }
            }

            _wishRepository.Save();

            return wishList;
        }

        /// <summary>
        /// Delete an item from the list
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="productId">Product Id</param>
        public void Delete(long userId, long productId)
        {
            _wishRepository.Delete(userId, productId);
        }

        /// <summary>
        /// Checks if exists an wish list item on the user list
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="productId">Product Id</param>
        /// <returns>True or false</returns>
        public bool Exists(long userId, long productId)
        {
            return _wishRepository.Exists(userId, productId);
        }

        /// <summary>
        /// Brings a list of whishes based on a paged query
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="page">Page</param>
        /// <returns>List of products</returns>
        public List<Product> FindWithPagedSearch(long userId, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;

            string query = @"SELECT * FROM Products p";
            query = query + $" WHERE p.Id IN";
            query = query + $" (SELECT w.IdProduct FROM Whishes w";
            query = query + $" WHERE w.IdUser = {userId})";
            query = query + $" ORDER BY p.Id ASC OFFSET({page}) * {pageSize}";
            query = query + $" ROWS FETCH NEXT {pageSize} ROWS ONLY";

            return _productRepository.FindWithPagedSearch(query);
        }
    }
}
