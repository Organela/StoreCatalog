using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;
using System.Data.SqlClient;
using System.Linq;

namespace Storage.Catalog.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository<Book>
    {
        public void Delete(Book entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Book entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public IList<Book> GetAll(string defaultConnection)
        {
            List<Book> books = new List<Book>();
            using (IDbConnection db = new SqlConnection(defaultConnection/*ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString)*/))
            {
                books = db.Query<Book>("Select * From Book").ToList();
            }
            return books;

            //throw new NotImplementedException();
        }

        public Task<IList<Book>> GetAllAsync(string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Book GetById(int id, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetByIdAsync(int id, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Book Save(Book entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }

        public Task<Book> SaveAsync(Book entity, string defaultConnection)
        {
            throw new NotImplementedException();
        }
    }
}
