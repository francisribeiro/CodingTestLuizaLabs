using CodingTestLuizaLabs.Model.Base;
using CodingTestLuizaLabs.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTestLuizaLabs.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        private readonly DbSet<T> _dataset;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        /// <summary>
        /// Create a generic item
        /// </summary>
        /// <param name="entity">Generic item</param>
        /// <returns>New item</returns>
        public T Create(T entity)
        {
            try
            {
                _dataset.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete item based on Id
        /// </summary>
        /// <param name="id">Id</param>
        public void Delete(long id)
        {
            var result = _dataset.SingleOrDefault(i => i.Id.Equals(id));

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

        /// <summary>
        /// Check if there is an item based on id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>True or false</returns>
        public bool Exists(long? id)
        {
            return _dataset.Any(i => i.Id.Equals(id));
        }

        /// <summary>
        /// Brings a list of items based on a paged query
        /// </summary>
        /// <param name="query">Query</param>
        /// <returns>Item list</returns>
        public List<T> FindWithPagedSearch(string query)
        {
            return _dataset.FromSql(query).ToList();
        }

        /// <summary>
        /// Update a generic item
        /// </summary>
        /// <param name="entity">Generic item</param>
        /// <returns>Item updated</returns>
        public T Update(T entity)
        {
            if (!Exists(entity.Id)) return null;

            var result = _dataset.SingleOrDefault(i => i.Id.Equals(entity.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }
    }
}
