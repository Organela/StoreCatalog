using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.Infrastructure.Repositories
{
    public class DvdRepository : IDvdRepository
    {
        private readonly ConnectionString ConnectionString;

        public DvdRepository(ConnectionString connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                return await sqlConnection.ExecuteAsync(@"DELETE FROM Dvd WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task<IEnumerable<Dvd>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                return (await sqlConnection.QueryAsync<Dvd>("SELECT * FROM Dvd")).ToList(); 
            }
        }

        public async Task<Dvd> GetByIdAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                return await sqlConnection.QueryFirstOrDefaultAsync<Dvd>("SELECT * FROM Dvd WHERE Id = @id", new { Id = id });
            }
        }

        public async Task<int> SaveAsync(Dvd dvd)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                if (await GetByIdAsync(dvd.Id) != null)
                {
                    return await sqlConnection.ExecuteAsync(@"UPDATE Dvd SET 
                                                 Synopsis = @Synopsis 
                                                 ,Cover = @Cover 
                                                 ,Title = @Title 
                                                 ,ReleaseDate = @ReleaseDate
                                                 ,Image = @Image
                                                 WHERE Id = @Id", dvd);
                }

                return await sqlConnection.ExecuteAsync(
                    @"INSERT INTO DBO.Dvd(Synopsis, Cover, Title, ReleaseDate, Image)  
                    VALUES(@Synopsis, @Cover, @Title, @ReleaseDate, @Image)",
                    dvd);
            }
        }
    }
}
