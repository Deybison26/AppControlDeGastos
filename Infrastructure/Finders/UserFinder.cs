using AppControlDeGatos.Domain.Interfaces;
using AppControlDeGatos.Domain.Models;
using MongoDB.Driver;

namespace AppControlDeGatos.Infrastructure.Finders
{
    public class UserFinder : IUserFinder
    {
        private IMongoDatabase _database = null;
        private readonly IMongoCollection<User> _collection;
        public UserFinder(IConfiguration configuration, IMongoDbContext context)
        {
            _collection = context.GetCollection<User>("User");
        }
        public async Task<List<User>> GetAllUsers()
        {
            var filter = Builders<User>.Filter.Empty;
            var result = await _collection.Find(filter).ToListAsync();
            return result;
        }
        public Task<User> GetByEmailAsync(string email)
        {
            var filter = Builders<User>.Filter.Eq("Email", email);
            return _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var filter = Builders<User>.Filter.Eq("_id", id);
            var result = await _collection.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public Task<User> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
