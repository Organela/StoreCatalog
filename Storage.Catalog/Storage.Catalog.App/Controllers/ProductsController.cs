using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage.Catalog.Domain;
using Storage.Catalog.Domain.Repositories;
using Storage.Catalog.Infrastructure.Repositories;

namespace Storage.Catalog.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository<Product> _productRepository;

        public ProductsController(IProductRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {             
           // var products = new List<Product>();
            //products = _productRepository.GetAll();
            return _productRepository.GetAll("Batatinha"); 
            
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
