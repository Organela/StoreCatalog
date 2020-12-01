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
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository BookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        [HttpGet("{id}/image")]
        public async Task<IActionResult> GetImage(int id)
        {
            var book = await BookRepository.GetByIdAsync(id);
            return File(book.Image, "image/jpeg");
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await BookRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await BookRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {          
            var book = await GetBookFromForm();
            book.Id = await BookRepository.SaveAsync(book);
            return Created($"/books/{book.Id}", book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id )
        {
            if (BookRepository.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            await BookRepository.SaveAsync(await GetBookFromForm());
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(BookRepository.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            await BookRepository.DeleteAsync(id);

            return Ok();
        }

        private async Task<Book> GetBookFromForm()
        {
            var book = JsonConvert.DeserializeObject<Book>(Request.Form["productData"]);

            if (!Request.Form.Files.Any())
            {
                return book;
            }

            var formFileStream = Request.Form.Files.First().OpenReadStream();
            var buffer = new byte[formFileStream.Length];

            await formFileStream.ReadAsync(buffer, 0, buffer.Length);

            book.Image = buffer;

            return book;
        }
    }
}
