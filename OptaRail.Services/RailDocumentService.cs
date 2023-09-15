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
        private readonly IUnitOfWork _unitOfWork;

        private readonly IGenericRepository<RailDocument> _railDocumentRepository;


        public RailDocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _railDocumentRepository = unitOfWork.GetRepository<RailDocument>();
        }

        public IEnumerable<RailDocument> GetRailDocuments()
        {
            return _railDocumentRepository.GetAll();
        }

        public RailDocument GetRailDocumentById(string id)
        {
           return _railDocumentRepository.Get(x =>x.Id == id );
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
