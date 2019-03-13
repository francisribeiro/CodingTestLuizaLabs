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
        protected readonly SqlContext _context;
        private readonly DbSet<Wish> _dataset;

        public WishRepository(SqlContext context)
        {
            _context = context;
            _dataset = _context.Set<Wish>();
        }

        public void Create(Wish entity)
        {
            _dataset.Add(entity);
        }

        public void Delete(long userId, long productId)
        {
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
