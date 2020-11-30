using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public async Task<int> DeleteAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                return await sqlConnection.ExecuteAsync(@"DELETE FROM Book WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                return (await sqlConnection.QueryAsync<Book>("SELECT * FROM Book")).ToList();
            }
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                return await sqlConnection.QueryFirstOrDefaultAsync<Book>("SELECT * FROM Book WHERE Id = @id", new { Id = id });
            }
        }

        public async Task<int> SaveAsync(Book book)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                if (await GetByIdAsync(book.Id) != null)
                {
                    return await sqlConnection.ExecuteAsync(@"UPDATE Book SET 
                                                 Author = @Author 
                                                 ,Cover = @Cover 
                                                 ,Title = @Title 
                                                 ,ReleaseDate = @ReleaseDate
                                                 ,Image = @Image
                                                 WHERE Id = @Id", book);
                }

                return await sqlConnection.ExecuteAsync(
                    @"INSERT INTO DBO.Book(Author, Cover, Title, ReleaseDate, Image)  
                    VALUES(@Author, @Cover, @Title, @ReleaseDate, @Image)",
                    book);
            }
        }
    }
}
