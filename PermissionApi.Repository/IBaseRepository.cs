using Microsoft.EntityFrameworkCore;
using PermissionManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionManagement.Repository
{
    public interface IBaseRepository<Entity>
    {
        Task<int> AddAsync(Entity entity);
        Task UpdateAsync(Entity entity);
        Task RemoveAsync(int key);
        Task<Entity> GetByIdAsync(int key);
        Task<IEnumerable<Entity>> GetAllAsync(Func<Entity, bool> predicate = null);
        IQueryable<Entity> Query();
    }

    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : class, IBaseEntity
    {
        private readonly DbContext _dbContext;
        protected readonly DbSet<Entity> _dbSet;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Entity>();
        }
        public async Task<int> AddAsync(Entity entity)
        {
            var result = await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task UpdateAsync(Entity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int key)
        {
            var item = await GetByIdAsync(key);
            _dbSet.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Entity> GetByIdAsync(int key)
        {
            var entity = await _dbSet.Where(x=> x.Id == key).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<IEnumerable<Entity>> GetAllAsync(Func<Entity, bool> predicate = null)
        {
            var query = predicate == null ? _dbContext.Set<Entity>() : _dbContext.Set<Entity>().Where(predicate).AsQueryable();
            return await query.ToListAsync();
        }

        public IQueryable<Entity> Query()
        {
            return _dbSet;
        }
    }
}
