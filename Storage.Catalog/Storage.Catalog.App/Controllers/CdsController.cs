using Microsoft.AspNetCore.Mvc;
using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CdsController : ProductsController<Cd>
    {
        public CdsController(ICdRepository cdRepository) : base(cdRepository)
        {
        }
    }
}
