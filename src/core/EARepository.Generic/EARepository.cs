using EACrossCuttingConcerns.Generic;
using EARepository.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public async Task AddAsync(T entity)
        {

            entity.CreatedDate = DateTime.Now;

            await _dbSet.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }

        public void Delete(T entity)
        {

            _dbSet.Remove(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            _dbSet.Remove(entity);
        }

        public async Task Delete(Expression<Func<T, bool>> predicate)
        {
            var entity = await GetById(predicate);

            _dbSet.Remove(entity);
        }

        public void SoftDelete(T entity)
        {
            entity.DeletedDate = DateTime.UtcNow;
            _dbSet.Update(entity);
        }

        public async Task SoftDelete(int id)
        {
            var entity = await GetById(id);
            entity.DeletedDate = DateTime.UtcNow;
            _dbSet.Update(entity);
        }

        public async Task SoftDelete(Expression<Func<T, bool>> predicate)
        {
            var entity = await GetById(predicate);
            entity.DeletedDate = DateTime.UtcNow;
            _dbSet.Update(entity);
        }

        public void DeleteRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }


        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<T> GetAllQuery()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, bool? withDeleted = false)
        {
            if (withDeleted is true)
            {
                return await _dbSet.Where(predicate).ToListAsync();
            }
            else
            {
                var query = _dbSet.Where(x => !x.DeletedDate.HasValue);
                return await query.Where(predicate).ToListAsync();
            }
        }

        public async Task<IEAPaginatedList<T>> GetAllPaginate(Expression<Func<T, bool>>? predicate = null, int pageIndex = 1, int pageSize = 10, bool? withDeleted = false)
        {
            IQueryable<T> query = _dbSet;
            if (withDeleted == true)
            {
                query = query.IgnoreQueryFilters();
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            query =query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var count = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);
            return new EAPaginatedList<T>(await query.ToListAsync(), count, totalPages);
            //if (withDeleted is false)
            //{
            //    _dbSet.IgnoreQueryFilters();
            //    var list = await _dbSet.Where(predicate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            //    var count = await _dbSet.CountAsync();
            //    var totalPages = (int)Math.Ceiling(count / (double)pageSize);
            //    return new EAPaginatedList<T>(list, count, totalPages);
            //}
            //else
            //{
            //    var query = _dbSet.Where(x => !x.DeletedDate.HasValue);
            //    var list = await query.Where(predicate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            //    var count = await query.CountAsync();
            //    var totalPages = (int)Math.Ceiling(count / (double)pageSize);
            //    return new EAPaginatedList<T>(list, count, totalPages);
            //}
        }
        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet?.FirstOrDefaultAsync(predicate);
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
