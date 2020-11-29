using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Storage.Catalog.Domain;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Product Save(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
