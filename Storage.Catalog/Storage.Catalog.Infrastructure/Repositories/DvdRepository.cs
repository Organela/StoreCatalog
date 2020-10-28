using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.Infrastructure.Repositories
{
    public class DvdRepository : IDvdRepository<Dvd>
    {
        public void Delete(Dvd entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Dvd entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public IList<Dvd> GetAll(string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Dvd>> GetAllAsync(string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Dvd GetById(int id, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task<Dvd> GetByIdAsync(int id, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Dvd Save(Dvd entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task<Dvd> SaveAsync(Dvd entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }
    }
}
