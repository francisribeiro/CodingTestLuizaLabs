using CodingTestLuizaLabs.Model;
using CodingTestLuizaLabs.Repository.Generic;
using System.Collections.Generic;

namespace CodingTestLuizaLabs.Business.Implementations
{
    public class UserBusinessImpl : GenericBusiness<User>, IUserBusiness
    {
        private readonly IRepository<User> _repository;

        public UserBusinessImpl(IRepository<User> repository) : base(repository)
        {
            _repository = repository;
        }

        public List<User> FindWithPagedSearch(int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;

            string query = @"SELECT * FROM Users u WHERE 1 = 1";
            query = query + $" ORDER BY u.Name DESC OFFSET({page}) * {pageSize}";
            query = query + $" ROWS FETCH NEXT {pageSize} ROWS ONLY";

            return _repository.FindWithPagedSearch(query);
        }
    }
}
