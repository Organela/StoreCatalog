using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Catalog.Domain.Repositories
{
    public interface IRepository<T>
    {
        void Delete(T entity, string defaultConnection);
        Task DeleteAsync(T entity, string defaultConnection);
        IList<T> GetAll(string defaultConnection);
        Task<IList<T>> GetAllAsync(string defaultConnection);
        T GetById(int id, string defaultConnection);
        Task<T> GetByIdAsync(int id, string defaultConnection);
        T Save(T entity, string defaultConnection);
        Task<T> SaveAsync(T entity, string defaultConnection);
        
    }
}
