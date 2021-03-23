using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accepted_Technical_Assignment.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        Task<T> Insert(T obj);
        Task<IEnumerable<T>> AddRange(IEnumerable<T> entities);
        Task<T> Update(T obj);
        Task<bool> Delete(object id);
    }
}
