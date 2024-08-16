using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EARepository.Abstractions
{
    public interface IEARepository<T> where T : class
    {
        public Task AddAsync(T entity);
        public Task AddRange(IEnumerable<T> entity);
        public void Delete(T entity);
        public Task Delete(int id);
        public Task Delete(Expression<Func<T, bool>> predicate);
        public void DeleteRange(List<T> entities);
        public Task<List<T>> GetAll();
        public Task<List<T>> GetAll(Expression<Func<T, bool>>? predicate,bool? withDeleted=false);
        public Task<IEAPaginatedList<T>> GetAllPaginate(Expression<Func<T, bool>>? predicate=null,int pageIndex=1,int pageSize=10,bool? withDeleted=false);
        public Task<T> GetById(int id);
        public Task<T> GetById(Expression<Func<T, bool>> predicate);
        public Task<T> Get(Expression<Func<T, bool>> predicate);
        public Task Update(T entity);
        public void UpdateRange(List<T> entity);
        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<bool> Contains(T entity);
    }
}
