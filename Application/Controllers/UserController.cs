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
        
    }
}