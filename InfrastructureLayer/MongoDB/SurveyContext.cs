using DomainLayer.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InfrastructureLayer.MongoDB
{
    public class SurveyContext
    {
        private readonly IMongoDatabase _database = null;

        public SurveyContext(/*IOptions<Settings> settings*/)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            if (client != null)
                _database = client.GetDatabase("Survey");//Creates new database if none exist
        }

        public IMongoCollection<Survey> Surveys
        {
            get
            {
                return _database.GetCollection<Survey>("Survey");
            }
        }
    }
}
