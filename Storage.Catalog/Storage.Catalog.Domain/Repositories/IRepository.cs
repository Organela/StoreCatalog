using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Catalog.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> SaveAsync(T entity);
        
    }
}
