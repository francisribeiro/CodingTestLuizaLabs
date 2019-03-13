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

        public Wish[] Create(long userId, Wish[] wishList)
        {
            foreach (Wish wish in wishList)
            {
                wish.SetUserId(userId);
                _wishRepository.Create(wish);
            }

            _wishRepository.Save();

            return wishList;
        }

        public void Delete(long userId, long productId)
        {
            _wishRepository.Delete(userId, productId);
        }

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
