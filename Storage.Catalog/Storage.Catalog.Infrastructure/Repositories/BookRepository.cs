using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ConnectionString ConnectionString;

        public BookRepository(ConnectionString connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                return  sqlConnection.Execute(@"DELETE FROM Book WHERE Id = @Id", new { id = id });
            }
        }

        public IList<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                return await sqlConnection.QueryAsync<Book>("SELECT * FROM Book");
            }
        }

        Book IRepository<Book>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                return sqlConnection.QueryFirstOrDefault<Book>("SELECT * FROM Book WHERE Id = @id", new { Id = id});
            }
          
        }

        public Book Save(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveAsync(Book book)
        {// Voltar e alterar isert para q seja possível adicionar uma imagem!
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                if(await GetByIdAsync(book.Id) != null)
                {
                    return sqlConnection.Execute(@"UPDATE Book SET 
                                                 Author = @Author 
                                                 ,Cover = @Cover 
                                                 ,Title = @Title 
                                                 ,ReleaseDate = @ReleaseDate
                                                 ,Image = @Image
                                                 WHERE Id = @Id", book);
                }

                return sqlConnection.Execute(
                    @"INSERT INTO DBO.Book(Author, Cover, Title, ReleaseDate, Image)  
                    VALUES(@Author, @Cover, @Title, @ReleaseDate, @Image)",
                    book);
            }

        }

     
    }
}
