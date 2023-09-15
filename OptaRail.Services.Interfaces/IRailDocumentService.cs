using System;
using System.Collections;
using System.Collections.Generic;
using OptaRail.Domain;
using OptaRail.Infrastructure.Interfaces;

namespace OptaRail.Services.Interfaces
{
    public interface IRailDocumentService
    {

     
        IEnumerable<RailDocument> GetRailDocuments();

        RailDocument GetRailDocumentById(string id);
        RailDocument GetRailDocumentByName(string name);

        void DeleteRailDocument(string id); 

    }
}
