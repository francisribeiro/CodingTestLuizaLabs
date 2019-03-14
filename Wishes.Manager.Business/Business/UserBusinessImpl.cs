using CodingTestLuizaLabs.Model;
using CodingTestLuizaLabs.Repository.Generic;
using System.Collections.Generic;

namespace CodingTestLuizaLabs.Business.Implementations
{
    public class UserBusinessImpl : GenericBusiness<User>, IUserBusiness
    {
        private readonly IRepository<User> _repository;
        private readonly IUserRepository _userRepository;

        public UserBusinessImpl(IRepository<User> repository, IUserRepository userRepository) : base(repository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">User entity</param>
        /// <returns>User created</returns>
        public new User Create(User user)
        {
            // If there is no user with the email registered
            if (!Exists(user.Email))
                _repository.Create(user);

            return user;
        }

        /// <summary>
        ///  Check if there is a user with the email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>True or false</returns>
        public bool Exists(string email)
        {
            return _userRepository.Exists(email);
        }

        /// <summary>
        /// Brings a list of users based on a paged query
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="page">Page</param>
        /// <returns>List of Users</returns>
        public List<User> FindWithPagedSearch(int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;

            string query = @"SELECT * FROM Users u WHERE 1 = 1";
            query = query + $" ORDER BY u.Name ASC OFFSET({page}) * {pageSize}";
            query = query + $" ROWS FETCH NEXT {pageSize} ROWS ONLY";

            return _repository.FindWithPagedSearch(query);
        }
    }
}
