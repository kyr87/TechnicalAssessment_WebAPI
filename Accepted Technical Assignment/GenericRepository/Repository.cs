using Accepted_Technical_Assignment.Models.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accepted_Technical_Assignment.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SportBetContext _context;

        public Repository(SportBetContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<IEnumerable<T>> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            await _context.SaveChangesAsync();

            return entities;
        }

        public async Task<T> Update(T obj)
        {
            _context.Set<T>().Update(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(object id)
        {
            T selected = await GetById(id);
            if (selected == null)
                return false;

            _context.Set<T>().Remove(selected);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
