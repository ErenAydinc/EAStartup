using Microsoft.EntityFrameworkCore;

namespace Core.EAInfrastructure
{
    public class UnitOfWork<TContext>:IUnitOfWork where TContext:DbContext
    {
        private bool disposed = false;

        private TContext _context;
        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        IEARepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new EARepository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
