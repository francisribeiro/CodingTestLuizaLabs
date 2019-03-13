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
        protected readonly SqlContext _context;
        private readonly DbSet<T> _dataset;

        public GenericRepository(SqlContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

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

        public bool Exists(long? id)
        {
            return _dataset.Any(i => i.Id.Equals(id));
        }

        public List<T> FindWithPagedSearch(string query)
        {
            return _dataset.FromSql(query).ToList();
        }

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
