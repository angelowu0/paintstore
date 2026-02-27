using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PaintStore.API.DataAccess;
using PaintStore.API.Models;

namespace PaintStore.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private PaintStoreDbContext _dbContext;

        public UserController(PaintStoreDbContext paintStoreDb)
        {
            _dbContext = paintStoreDb;
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] User user)
        {
            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();

            return Created("GetUserById", user);
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            List<User> users = [.. _dbContext.Users];

            if (users.Any())
            {
                return Ok(users);
            }

            return NotFound();
        }

        [HttpGet("GetUser/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(user => user.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("GetUsersByName/{name}")]
        public IActionResult GetUserByName(string name)
        {
            List<User> users = [.. _dbContext.Users];

            if (users.Any(user => user.Name == name))
            {
                return Ok(users.Select(user => user.Name == name));
            }

            return NotFound();
        }

        [HttpGet("GetUsersByEmail/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            List<User> users = [.. _dbContext.Users];

            if (users.Any(user => user.Email == email))
            {
                return Ok(users.Select(user => user.Email == email));
            }

            return NotFound();
        }
    }
}
