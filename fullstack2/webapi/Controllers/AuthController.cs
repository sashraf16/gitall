using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Dtos;
using webapi.Services;

namespace fullstack2.Controllers
{
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private UserRepo _uRepo = new UserRepo();

        [HttpPost]
        [Route("login")]
        public User Login ([FromBody]AttemptUser user)
        {
            return _uRepo.Login(user);
        }
    }
}