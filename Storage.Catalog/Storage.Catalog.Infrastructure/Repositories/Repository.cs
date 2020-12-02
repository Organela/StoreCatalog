using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Storage.Catalog.Domain.Entities;
using Storage.Catalog.Domain.Repositories;
using Storage.Catalog.Infrastructure.Database;

namespace Storage.Catalog.Infrastructure.Repositories
{
    public abstract class Repository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : IEntity<TId>
    {
        private const string InsertFormat = @"
INSERT INTO {0} ({1}) VALUES ({2});
SELECT SCOPE_IDENTITY();";
        private const string UpdateFormat = "UPDATE {0} SET {1} WHERE Id = @Id";
        private readonly IConnectionProvider connectionProvider;

        protected SqlConnection Connection => connectionProvider.Connection;

        public Repository(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public async Task DeleteAsync(TId id)
        {
            await Connection.ExecuteAsync($"DELETE FROM {typeof(TEntity).Name} WHERE Id = @Id", new { Id = id });
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Connection.QueryAsync<TEntity>($"SELECT * FROM {typeof(TEntity).Name}");
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await Connection.QueryFirstOrDefaultAsync<TEntity>($"SELECT * FROM {typeof(TEntity).Name} WHERE Id = @Id", new { Id = id });
        }

        public virtual async Task SaveAsync(TEntity entity)
        {
            var entityType = typeof(TEntity);
            var propertyNames = entityType.GetProperties()
                .Where(p => p.Name != nameof(IEntity<TId>.Id))
                .Select(p => p.Name).ToList();
            if (!entity.Id.Equals(default(TId)))
            {
                var columnAssignments = string.Join(",", propertyNames.Select(n => $"{n} = @{n}"));

                await Connection.ExecuteAsync(string.Format(UpdateFormat, entityType.Name, columnAssignments), entity);
                return;
            }

            entity.Id = await Connection.ExecuteScalarAsync<TId>(string.Format(InsertFormat,
                entityType.Name, string.Join(",", propertyNames), string.Join(",", propertyNames.Select(n => $"@{n}"))), entity);
        }
    }
}
