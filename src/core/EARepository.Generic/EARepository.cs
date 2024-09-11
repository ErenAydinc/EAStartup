using EACrossCuttingConcerns.Generic;
using EARepository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EARepository.Generic
{
    public class EARepository<T> : IEARepository<T> where T : EAEntity
    {
        private DbContext _context;
        private DbSet<T> _dbSet;
        public EARepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Create(T entity)
        {

            entity.CreatedDate = DateTime.Now;

            await _dbSet.AddAsync(entity);
        }

        public async Task CreateRange(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }

        public async Task Delete(T entity)
        {
            await Task.FromResult(_dbSet.Remove(entity));
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            _dbSet.Remove(entity);
        }

        public async Task SoftDelete(T entity)
        {
            entity.DeletedDate = DateTime.UtcNow;
            await Task.FromResult(_dbSet.Update(entity));
        }

        public async Task SoftDelete(int id)
        {
            var entity = await GetById(id);
            entity.DeletedDate = DateTime.UtcNow;
            _dbSet.Update(entity);
        }

        public void DeleteRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task SoftDeleteRange(List<int> ids)
        {

            foreach (var id in ids)
            {
                var entity = await GetById(id);
                entity.DeletedDate = DateTime.UtcNow;
                _dbSet.Update(entity);
            }
        }


        public async Task<List<T>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public IQueryable<T> GetAllQuery()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, bool? withDeleted = false)
        {
            if (withDeleted is true)
            {
                return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
            }
            else
            {
                var query = _dbSet.Where(x => !x.DeletedDate.HasValue);
                return await query.Where(predicate).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IEAPaginatedList<T>> GetAllPaginate(Expression<Func<T, bool>>? predicate = null, int pageIndex = 1, int pageSize = 10, bool? withDeleted = false)
        {
            IQueryable<T> query = _dbSet;
            if (withDeleted == true)
            {
                query = query.IgnoreQueryFilters();
            }
            if (withDeleted == false)
            {
                query = query.Where(x => !x.DeletedDate.HasValue);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            var count = await query.CountAsync();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);
            var pageItemsCount = await query.CountAsync();
            return new EAPaginatedList<T>(await query.AsNoTracking().ToListAsync(), pageIndex, pageSize, totalPages, pageItemsCount, count);
        }
        public async Task<T?> Get(Expression<Func<T, bool>> predicate, bool? withDeleted=false)
        {
            IQueryable<T> query = _dbSet;
            if (withDeleted is true)
                query = query.IgnoreQueryFilters();
            else
                query = query.Where(x=>!x.DeletedDate.HasValue);

            return await query.FirstOrDefaultAsync(predicate);
        }
        public async Task<T?> GetById(int id, bool? withDeleteted=false)
        {
            if (withDeleteted is true)
                return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            else
                return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && !x.DeletedDate.HasValue);
        }
        public async Task Update(T entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            await Task.FromResult(_dbSet.Update(entity));
        }

        public void UpdateRange(List<T> entity)
        {
            _dbSet.UpdateRange(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public Task<bool> Contains(T entity)
        {
            return _dbSet.ContainsAsync(entity);
        }
    }
}
