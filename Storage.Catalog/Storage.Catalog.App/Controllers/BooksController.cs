using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.App.Controllers
{
    public class BooksController : ProductsController<Book>
    {
        public BooksController(IBookRepository bookRepository) : base(bookRepository)
        {
        }
    }
}
