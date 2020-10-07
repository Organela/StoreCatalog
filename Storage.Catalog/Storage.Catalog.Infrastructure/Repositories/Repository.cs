using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public T Save(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> SaveAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
