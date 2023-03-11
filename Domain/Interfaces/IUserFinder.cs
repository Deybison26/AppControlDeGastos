using AppControlDeGatos.Domain.Models;


namespace AppControlDeGatos.Domain.Interfaces
{
    public interface IUserFinder
    {
        public Task<User> GetByIdAsync(string id);
        public Task<List<User>> GetAllUsers();
        public Task<User> GetByNameAsync(string name);
        public Task<User> GetByEmailAsync(string product);
    }
}
