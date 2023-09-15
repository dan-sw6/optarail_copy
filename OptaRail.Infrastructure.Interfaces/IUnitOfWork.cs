using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptaRail.Infrastructure.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<T>? GetRepository<T>() where T : class;
        void Commit();
        void Rollback(); 
        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}
