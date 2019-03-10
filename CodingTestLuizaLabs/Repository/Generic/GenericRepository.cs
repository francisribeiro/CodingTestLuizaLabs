﻿using CodingTestLuizaLabs.Model.Base;
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

        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();
                return item;
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

        public T FindById(long id)
        {
            return _dataset.SingleOrDefault(i => i.Id.Equals(id));
        }

        public List<T> FindWithPagedSearch(string query)
        {
            return _dataset.FromSql<T>(query).ToList();
        }

        // https://stackoverflow.com/questions/40557003/entity-framework-core-count-does-not-have-optimal-performance
        public int GetCount(string query)
        {
            var result = "";

            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    result = command.ExecuteScalar().ToString();
                }
            }

            return Int32.Parse(result);
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;

            var result = _dataset.SingleOrDefault(i => i.Id.Equals(item.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
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