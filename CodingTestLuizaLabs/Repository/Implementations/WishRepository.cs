using System;
using System.Collections.Generic;
using System.Linq;
using CodingTestLuizaLabs.Model;
using CodingTestLuizaLabs.Model.Context;
using CodingTestLuizaLabs.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace CodingTestLuizaLabs.Repository.Implementations
{
    public class WishRepository : IWishRepository
    {
        protected readonly SqlContext _context;
        private readonly DbSet<Wish> _dataset;

        public WishRepository(SqlContext context)
        {
            _context = context;
            _dataset = _context.Set<Wish>();
        }

        public void Delete(long userId, long productId)
        {
            var result = _dataset.SingleOrDefault(w => w.UserId.Equals(userId) && w.ProductId.Equals(productId));

            try
            {
                if (result != null)
                {
                    _dataset.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
