using AppControlDeGatos.Domain.Interfaces;
using AppControlDeGatos.Domain.Models;
using MongoDB.Driver;
using System.Xml;

namespace AppControlDeGatos.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IMongoDatabase _database = null;
        private readonly IMongoCollection<User> _collection;
        public UserRepository(IConfiguration configuration, IMongoDbContext context)
        {
            _collection = context.GetCollection<User>("User");
        }

        public async Task<User> InsertAsync(User entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public Task DeleteAsync(string id)
        {
            return _collection.FindOneAndDeleteAsync(user => user.id == id);
        }

       
        public async Task<User> UpdateAsync(User entity)
        {
            var updated = await _collection.ReplaceOneAsync(user => user.id == entity.id, entity);
            return entity;
        }

        
    }
}