using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptaRail.Domain;
using OptaRail.Infrastructure.Interfaces;
using OptaRail.Services.Interfaces;

namespace OptaRail.Services
{
    public class RailDocumentService:IRailDocumentService
    {

        private IRailDocumentRepository _railDocumentRepository;

        public RailDocumentService(IRailDocumentRepository railDocumentRepository)
        {
            _railDocumentRepository = railDocumentRepository;
        }

        public IEnumerable<RailDocument> GetRailDocuments()
        {
            return _railDocumentRepository.GetAll();
        }

        public RailDocument GetRailDocument(string id)
        {
            throw new NotImplementedException();
        }

        public RailDocument GetRailDocumentById(string id)
        {
            throw new NotImplementedException();
        }

        public RailDocument GetRailDocumentByName(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteRailDocument(string id)
        {
            throw new NotImplementedException();
        }
    }
}
