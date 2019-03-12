using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace fullstack2.Controllers
{
    [Route("api/Users")]
    public class UsersController : Controller
    {

        private UserRepo _uRepo = new UserRepo();

        // GET api/users
        [HttpGet]
        public List<User> GetUsers()
        {
            return _uRepo.getUsers();
        }

        // GET api/users/5
        // [HttpGet("{username}")]
        [Route("{username}")]
        public User Get(string username)
        {
            return _uRepo.GetUser(username);
        }

        // GET api/users/hash
        // [HttpGet("{password}")]
        [Route("hash/{password}")]
        public string hash(string password)
        {

            return _uRepo.HashPassword(password);
        }

        // GET api/users/verify/password
        // [HttpGet("{pass}")]
        [Route("verify/{pass}")]
        public User verify(string pass)
        {
            return _uRepo.verifyUser(pass);
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody]User user)
        {
            var result =  _uRepo.insertUser(user);
            System.Console.WriteLine("controller results: " + result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
