using AppControlDeGatos.Domain.Interfaces;
using MongoDB.Driver;

namespace AppControlDeGatos.Infrastructure
{
    public class MongoDbContext: IMongoDbContext
    {
        private IMongoDatabase _database = null;

        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("Mongodb:ConnectionString").Value;
            var databaseName = configuration.GetSection("Mongodb:DatabaseName").Value;

            var client = new MongoClient(connectionString);
            if (client != null)
            {
                _database = client.GetDatabase(databaseName);
            }
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName)
        {
            return _database.GetCollection<TEntity>(collectionName);
        }
    }
}