using AppControlDeGatos.Domain.Models;


namespace AppControlDeGatos.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> InsertAsync(User entity);
        public Task<User> UpdateAsync(User entity);
        public Task DeleteAsync(string id);

    }
}