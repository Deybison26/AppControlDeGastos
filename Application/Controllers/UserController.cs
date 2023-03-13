using Microsoft.AspNetCore.Mvc;
using AppControlDeGatos.Domain.Interfaces;
using AppControlDeGatos.Domain.Models;

namespace miTienda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService= userService;

        }
        [HttpGet("~/GetUsers")]
        public async Task<List<User>> GetUsers()
        {
            var listUsers = await  userService.GetAllUsers();
            return listUsers; 
        }
        [HttpPost]
        public async Task<User> CreateUser(User user) {
            var result = await userService.InsertAsync(user);
            return user;
        }
        [HttpGet("~/GetUserByID")]
        public async Task<User> GetUserByID(string id)
        {
            var result = await userService.FindById(id); 
            return result; 
        }

        [HttpPost("~/login")]
        public dynamic Login(string email, string contrasenia) {
            var result = userService.LoginAsync(email, contrasenia);
            if(result.Result == null)
            {
                return new {
                    message = "Email o contraseña inválidos"
                };
            }
            
            return result.Result;
        }

        [HttpPost("~/sign-in")]
        public dynamic SignIn(string nombre, string apellidos, string nombre_usuario, string email, string contrasenia) {
            var result = userService.SignInAsync(nombre, apellidos, nombre_usuario, email, contrasenia);
            return result;
        }
        
    }
}
