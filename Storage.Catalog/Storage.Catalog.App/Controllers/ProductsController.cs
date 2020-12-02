using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController<TProduct> : ControllerBase where TProduct : Product
    {
        private readonly IRepository<int, TProduct> ProductRepository;

        public ProductsController(IRepository<int, TProduct> productRepository)
        {
            ProductRepository = productRepository;
        }

        [HttpGet("{id}/image")]
        public async Task<IActionResult> GetImage(int id)
        {
            var book = await ProductRepository.GetByIdAsync(id);
            return File(book.Image, "image/jpeg");
        }

        [HttpGet]
        public Task<IEnumerable<TProduct>> Get()
        {
            return ProductRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await ProductRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var product = await GetProductFromForm();
            await ProductRepository.SaveAsync(product);
            return Created($"{Request.Path}/{product.Id}", product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            if (await ProductRepository.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            await ProductRepository.SaveAsync(await GetProductFromForm());

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await ProductRepository.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            await ProductRepository.DeleteAsync(id);

            return Ok();
        }

        private async Task<TProduct> GetProductFromForm()
        {
            var product = JsonConvert.DeserializeObject<TProduct>(Request.Form["productData"]);

            if (!Request.Form.Files.Any())
            {
                return product;
            }

            var formFileStream = Request.Form.Files.First().OpenReadStream();
            var buffer = new byte[formFileStream.Length];

            await formFileStream.ReadAsync(buffer, 0, buffer.Length);

            product.Image = buffer;

            return product;
        }
    }
}
