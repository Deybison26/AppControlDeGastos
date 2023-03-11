using AppControlDeGatos.Domain.Interfaces;
using AppControlDeGatos.Domain.Models;

namespace AppControlDeGatos.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserFinder userFinder;
        public UserService(IUserRepository userRepository, IUserFinder userFinder)
        {
           this.userRepository = userRepository;
           this.userFinder = userFinder;
        }

        public async Task<User> FindByEmail(string email)
        {
            var result = await userFinder.GetByEmailAsync(email);
            return result;
        }

        public async Task<User> FindById(string id)
        {
            var result = await userFinder.GetByIdAsync(id);
            return result;
        }

        public Task<List<User>> GetAllUsers()
        {
            return userFinder.GetAllUsers();
        }

        public async Task<User> InsertAsync(User entity)
        {
            //todo if exist 
            var idGnerated = Guid.NewGuid().ToString();
            entity.Id = idGnerated;
            var result = await userRepository.InsertAsync(entity);
            return result;
        }
    }
}