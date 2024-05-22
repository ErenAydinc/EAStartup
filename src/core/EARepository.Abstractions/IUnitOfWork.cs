using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EARepository.Abstractions
{
    public interface IUnitOfWork:IDisposable
    {
        IEARepository<T> GetRepository<T>() where T : EAEntity; // İstediğimiz Generic Repositoryleri Tek bir yerden Üretmemizi sağlayacak.
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
