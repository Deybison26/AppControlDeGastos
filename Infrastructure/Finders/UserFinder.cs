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
            var filter = Builders<User>.Filter.Eq("email", email);
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
        public async Task<User> GetByEmailContraseniaAsync(string email, string contrasenia)
        {
            var filterUno = Builders<User>.Filter.Eq("email", email);
            var filterDos = Builders<User>.Filter.Eq("contrasenia", contrasenia);
            var combine = Builders<User>.Filter.And(filterUno, filterDos);
            var result = await _collection.Find(combine).FirstOrDefaultAsync();
            return result;
        }
    }
}
