using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Storage.Catalog.Domain.Entities;

namespace Storage.Catalog.Domain.Repositories
{
    public interface IRepository<TId, TEntity> where TEntity : IEntity<TId>
    {
        Task DeleteAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TId id);
        Task SaveAsync(TEntity entity);
        
    }
}
