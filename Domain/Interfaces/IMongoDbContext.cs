using MongoDB.Driver;

namespace AppControlDeGatos.Domain.Interfaces
{
    public interface IMongoDbContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName);
    }
}