using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.Infrastructure.Repositories
{
    public class CdRepository : ICdRepository<Cd>
    {
        public void Delete(Cd entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Cd entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public IList<Cd> GetAll(string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Cd>> GetAllAsync(string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Cd GetById(int id, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task<Cd> GetByIdAsync(int id, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Cd Save(Cd entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task<Cd> SaveAsync(Cd entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }
    }
}
