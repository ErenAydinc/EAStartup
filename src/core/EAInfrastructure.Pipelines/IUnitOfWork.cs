using Core.EADomain;

namespace EAInfrastructure
{
    public interface IUnitOfWork:IDisposable
    {
        IEARepository<T> GetRepository<T>() where T : EAEntity; // İstediğimiz Generic Repositoryleri Tek bir yerden Üretmemizi sağlayacak.
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
