using System.Collections.Generic;
using BlogsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogsApi.Controllers
{

    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private IUserRepository _users { get; set; }

        public UserController(IUserRepository userRepository)
        {
            _users = userRepository;
            
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
           return _users.GetAll();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _users.GetById(id);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
             _users.Add(user);
             return Ok(user);
        }

         [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _users.GetById(id);
            _users.Remove(id);
            return Ok(user);
        }

    }
}
