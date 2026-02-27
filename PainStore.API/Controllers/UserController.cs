using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Models;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet()]
        public IActionResult GetUsers()
        {
            List<User> users = [];

            if (users.Any())
            {
                return Ok(users);
            }

            return NotFound();
        }

        [HttpGet()]
        public IActionResult GetUserById(int id)
        {
            List<User> users = [];

            if (users.Any(user => user.Id == id))
            {
                return Ok(users.Select(user => user.Id == id));
            }

            return NotFound();
        }

        [HttpGet()]
        public IActionResult GetUserByName(string name)
        {
            List<User> users = [];

            if (users.Any(user => user.Name == name))
            {
                return Ok(users.Select(user => user.Name == name));
            }

            return NotFound();
        }

        [HttpGet()]
        public IActionResult GetUserByEmail(string email)
        {
            List<User> users = [];

            if (users.Any(user => user.Email == email))
            {
                return Ok(users.Select(user => user.Email == email));
            }

            return NotFound();
        }
    }
}
