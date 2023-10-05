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
    public class RailProjectService:IRailProjectService
    {   
        private readonly IUnitOfWork _unitOfWork;

        private readonly IGenericRepository<RailDocument>? _railDocumentRepository;


        public RailProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _railDocumentRepository = unitOfWork.GetRepository<RailDocument>();
        }

        public IEnumerable<RailDocument> GetRailDocuments()
        {
            return _railDocumentRepository.GetAll();
        }

        public RailDocument GetRailDocumentById(int id)
        {
           return _railDocumentRepository.Get(x =>x.Id == id );
        }

        public RailDocument GetRailDocumentByName(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteRailDocument(RailDocument railDocument)
        {
            _railDocumentRepository.Remove(railDocument);
            _unitOfWork.Commit();
        }

        public void AddRailDocument(RailDocument railDocument)
        {
            _railDocumentRepository.Add(railDocument);
            _unitOfWork.Commit();
        }
    }
}
