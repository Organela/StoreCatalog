using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void Delete(object entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(object entity)
        {
            throw new NotImplementedException();
        }

        public IList<object> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<object>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public object GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public object Save(object entity)
        {
            throw new NotImplementedException();
        }

        public Task<object> SaveAsync(object entity)
        {
            throw new NotImplementedException();
        }
    }
}
