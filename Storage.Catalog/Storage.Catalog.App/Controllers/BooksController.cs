﻿using System.Collections.Generic;
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


        // GET: api/Books
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await BookRepository.GetAllAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await BookRepository.GetByIdAsync(id));
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok(await BookRepository.SaveAsync(await GetBookFromForm()));
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

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put()
        {
            return Ok(await BookRepository.SaveAsync(await GetBookFromForm()));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await BookRepository.DeleteAsync(id));
        }
    }
}
