using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace fullstack2.Controllers 
{
    [Route ("api/[controller]")]
    public class SaltController : Controller {
        private SaltRepo _sRepo = new SaltRepo ();

        // GET api/salt
        [HttpGet]
        public int GetUsers () {
            return 1;
        }

        // GET api/salt/5
        [HttpGet ("{Userid}")]
        public Salts Get (int UserId) {
            return _sRepo.GetSalt(UserId);
        }

        // POST api/users
        [HttpPost]
        // public void Post ([FromBody] User user) {
        //     var result = _uRepo.insertUser (user);
        //     System.Console.WriteLine ("controller results: " + result);
        // }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}
