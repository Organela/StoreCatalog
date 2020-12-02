using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;
using Storage.Catalog.Infrastructure.Database;

namespace Storage.Catalog.Infrastructure.Repositories
{
    public class DvdRepository : Repository<int, Dvd>, IDvdRepository
    {
        public DvdRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
        {
        }

        public Task<IEnumerable<Dvd>> GetMostViewedMovies()
        {
            return Connection.QueryAsync<Dvd>("");
        }
    }
}
