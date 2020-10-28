using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.Infrastructure.Repositories
{
    public class ProductRepository<T> : IProductRepository<T>
    {
        public void Delete(T entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetAllAsync(string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public T Save(T entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task<T> SaveAsync(T entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }
    }
}
