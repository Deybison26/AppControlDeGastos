using AppControlDeGatos.Domain.Models;

namespace AppControlDeGatos.Domain.Interfaces
{
    public interface IUserService
    {
        public Task<User> InsertAsync(User entity);
        public Task<User> FindById(string id);
        public Task<List<User>> GetAllUsers();
        public Task<User> FindByEmail(string email);
        public Task<User> LoginAsync(string email, string contrasenia);
        public dynamic SignInAsync(string nombre, string apellidos, string nombre_usuario, string email, string contrasenia);
        //public dynamic CategoriesAsync(string marca, string mercado, string servicios, string gastos_v);
    }
}