using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using OptaRail.Domain;
using OptaRail.Infrastructure;
using OptaRail.Infrastructure.Interfaces;

namespace OptaRail.MongoDataAccess
{
    public class MongoRailDocumentRepository:IRailDocumentRepository
    {
        private MongoClient _client;
        public MongoRailDocumentRepository(string dataContext)
        {
            _client = new MongoClient(dataContext);
        }

        public IEnumerable<RailDocument> GetAll()
        {
            BsonClassMap.RegisterClassMap<RailDocument>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty("Id");
            });
            
            
            return new List<RailDocument>();

        }

        public RailDocument GetById(int railDocumentId)
        {
            throw new NotImplementedException();
        }

        public void Insert(RailDocument railDocument)
        {
            throw new NotImplementedException();
        }

        public void Update(RailDocument railDocument)
        {
            throw new NotImplementedException();
        }

        public void Delete(int railDocumentId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }

}
