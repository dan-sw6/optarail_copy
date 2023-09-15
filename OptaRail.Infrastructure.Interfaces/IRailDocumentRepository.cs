using System.Collections.Generic;
using System.Threading.Tasks;
using OptaRail.Domain;

namespace OptaRail.Infrastructure.Interfaces
{
    public interface IRailDocumentRepository
    {
        IEnumerable<RailDocument> GetAll();
        RailDocument GetById(int railDocumentId);
        void Insert(RailDocument railDocument);
        void Update(RailDocument railDocument);
        void Delete(int railDocumentId);
        void Save();
    }
}
