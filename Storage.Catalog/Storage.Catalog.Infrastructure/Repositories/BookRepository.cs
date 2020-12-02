using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;
using Storage.Catalog.Infrastructure.Database;

namespace Storage.Catalog.Infrastructure.Repositories
{
    public class BookRepository : Repository<int, Book>, IBookRepository
    {
        public BookRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
        {
        }
    }
}
