using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                return sqlConnection.Execute(@"DELETE FROM Dvd WHERE Id = @Id", new { id = id });
            }
        }

        public IList<Dvd> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Dvd>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                return await sqlConnection.QueryAsync<Dvd>("SELECT * FROM Dvd");
            }
        }

        public Dvd GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Dvd> GetByIdAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                return sqlConnection.QueryFirstOrDefault<Dvd>("SELECT * FROM Dvd WHERE Id = @id", new { Id = id });
            }
        }

        public Dvd Save(Dvd entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveAsync(Dvd dvd)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                if (await GetByIdAsync(dvd.Id) != null)
                {
                    return sqlConnection.Execute(@"UPDATE Dvd SET 
                                                 Synopsis = @Synopsis 
                                                 ,Cover = @Cover 
                                                 ,Title = @Title 
                                                 ,ReleaseDate = @ReleaseDate
                                                 ,Image = @Image
                                                 WHERE Id = @Id", dvd);
                }

                return sqlConnection.Execute(
                    @"INSERT INTO DBO.Dvd(Synopsis, Cover, Title, ReleaseDate, Image)  
                    VALUES(@Synopsis, @Cover, @Title, @ReleaseDate, @Image)",
                    dvd);
            }
        }
    }
}
