using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;
using Storage.Catalog.Infrastructure.Database;

namespace Storage.Catalog.Infrastructure.Repositories
{
    public class CdRepository : Repository<int, Cd>, ICdRepository
    {
        public CdRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
        {
        }
    }
}
