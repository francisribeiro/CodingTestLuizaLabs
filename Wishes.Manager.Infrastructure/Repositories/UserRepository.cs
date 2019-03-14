using CodingTestLuizaLabs.Model;
using CodingTestLuizaLabs.Model.Context;
using CodingTestLuizaLabs.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CodingTestLuizaLabs.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        protected readonly DataContext _context;
        private readonly DbSet<User> _dataset;

        public UserRepository(DataContext context)
        {
            _context = context;
            _dataset = _context.Set<User>();
        }

        /// <summary>
        /// Check if there is a user with the email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>True or false</returns>
        public bool Exists(string email)
        {
            return _dataset.Any(u => u.Email.Equals(email));
        }
    }
}
