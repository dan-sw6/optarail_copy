using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptaRail.Infrastructure.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRailDocumentRepository RailDocuments { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
