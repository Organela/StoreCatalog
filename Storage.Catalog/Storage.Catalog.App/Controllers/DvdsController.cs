using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.App.Controllers
{
    public class DvdsController : ProductsController<Dvd>
    {
        public DvdsController(IDvdRepository dvdRepository) : base(dvdRepository)
        {
        }
    }
}
