using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Catalog.Domain.Repositories
{
    public interface IRepository<T>
    {
        void Delete(int id);
        Task<int> DeleteAsync(int id);
        IList<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        T Save(T entity);
        Task<int> SaveAsync(T entity);
        
    }
}
