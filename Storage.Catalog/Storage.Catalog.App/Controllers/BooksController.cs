using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository<Book> _bookRepository;
        private readonly ConnectionString _connectionString;

        public BooksController(IBookRepository<Book> bookRepository, ConnectionString connectionString)
        {
            _bookRepository = bookRepository;
            _connectionString = connectionString;
        }

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookRepository.GetAll(_connectionString.DefaultConnection);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
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
