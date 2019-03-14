using CodingTestLuizaLabs.Model;
using CodingTestLuizaLabs.Model.Context;
using CodingTestLuizaLabs.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CodingTestLuizaLabs.Repository.Implementations
{
    public class WishRepository : IWishRepository
    {
        protected readonly DataContext _context;
        private readonly DbSet<Wish> _dataset;

        public WishRepository(DataContext context)
        {
            _context = context;
            _dataset = _context.Set<Wish>();
        }

        /// <summary>
        /// Create a new wish list
        /// </summary>
        /// <param name="entity">Wish list item</param>
        public void Create(Wish entity)
        {
            _dataset.Add(entity);
        }

        /// <summary>
        /// Delete an item from a wish list
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="productId">Product Id</param>
        public void Delete(long userId, long productId)
        {
            // If the user exists we can delete it
            var result = _dataset.SingleOrDefault(w => w.IdUser.Equals(userId) && w.IdProduct.Equals(productId));

            try
            {
                if (result != null)
                {
                    _dataset.Remove(result);
                    Save();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check if there is an item in the list
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="productId">Product Id</param>
        /// <returns></returns>
        public bool Exists(long userId, long productId)
        {
            return _dataset.Any(w => w.IdUser.Equals(userId) && w.IdProduct.Equals(productId));
        }

        /// <summary>
        /// Save the changes
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
