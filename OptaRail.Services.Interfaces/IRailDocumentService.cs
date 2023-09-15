using System;
using System.Collections;
using System.Collections.Generic;
using OptaRail.Domain;

namespace OptaRail.Services.Interfaces
{
    public interface IRailDocumentService
    {
        IEnumerable<RailDocument> GetRailDocuments();

        RailDocument GetRailDocument(string id);
        RailDocument GetRailDocumentById(string id);
        RailDocument GetRailDocumentByName(string name);

        void DeleteRailDocument(string id); 

    }
}
