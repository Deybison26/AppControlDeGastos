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
            entity.id = idGnerated;
            var result = await userRepository.InsertAsync(entity);
            return result;
        }

        public async Task<User> LoginAsync(string email, string contrasenia)
        {
            var emailVerificacion = await userFinder.GetByEmailContraseniaAsync(email, contrasenia);
            return emailVerificacion;
            
        }
        public dynamic SignInAsync(string nombre, string apellidos, string nombre_usuario, string email, string contrasenia)
        {
            var user = new User();
            var idGnerated = Guid.NewGuid().ToString();
            user.id = idGnerated;
            user.nombres = nombre;
            user.apellidos = apellidos;
            user.nombre_de_usuario = nombre_usuario;
            user.email = email;
            user.contrasenia = contrasenia;
            
            var emailVerified = userFinder.GetByEmailAsync(user.email);
            if(emailVerified.Result == null){
                var userSave = userRepository.InsertAsync(user);
                return userSave.Result;
            }else{
                return new {
                    message = "Email ya registrado"
                };
            }
            
        }
    }
}