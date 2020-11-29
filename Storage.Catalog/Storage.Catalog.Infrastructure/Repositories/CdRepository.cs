using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;

namespace Storage.Catalog.Infrastructure.Repositories
{
    public class CdRepository : ICdRepository
    {
        private readonly ConnectionString ConnectionString;

        public CdRepository(ConnectionString connectionString)
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
                return sqlConnection.Execute(@"DELETE FROM Cd WHERE Id = @Id", new { id = id });
            }
        }

        public IList<Cd> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cd>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                return await sqlConnection.QueryAsync<Cd>("SELECT * FROM Cd");
            }
        }

        public Cd GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Cd> GetByIdAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                return sqlConnection.QueryFirstOrDefault<Cd>("SELECT * FROM Cd WHERE Id = @id", new { Id = id });
            }
        }

        public Cd Save(Cd entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveAsync(Cd cd)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString.DefaultConnection))
            {
                if (await GetByIdAsync(cd.Id) != null)
                {
                    return sqlConnection.Execute(@"UPDATE Cd SET 
                                                 Artist = @Artist 
                                                 ,Cover = @Cover 
                                                 ,Title = @Title 
                                                 ,ReleaseDate = @ReleaseDate
                                                 ,Image = @Image
                                                 WHERE Id = @Id", cd);
                }

                return sqlConnection.Execute(
                    @"INSERT INTO DBO.Cd(Artist, Cover, Title, ReleaseDate, Image)  
                    VALUES(@Artist, @Cover, @Title, @ReleaseDate, @Image)",
                    cd);
            }
        }
    }
}
