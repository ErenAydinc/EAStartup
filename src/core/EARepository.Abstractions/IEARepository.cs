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
        public Task Create(T entity);
        public Task CreateRange(IEnumerable<T> entity);
        public Task Delete(T entity);
        public Task Delete(int id);
        public Task SoftDelete(T entity);
        public Task SoftDelete(int id);
        public void DeleteRange(List<T> entities);
        public Task SoftDeleteRange(List<int> ids);
        public Task<List<T>> GetAll();
        public Task<List<T>> GetAll(Expression<Func<T, bool>>? predicate,bool? withDeleted=false);
        public Task<IEAPaginatedList<T>> GetAllPaginate(Expression<Func<T, bool>>? predicate=null,int pageIndex=1,int pageSize=10,bool? withDeleted=false);
        public Task<T?> GetById(int id,bool? withDeleteted = false);
        public Task<T?> Get(Expression<Func<T, bool>> predicate, bool? withDeleteted= false);
        public Task Update(T entity);
        public void UpdateRange(List<T> entity);
        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<bool> Contains(T entity);
    }
}
