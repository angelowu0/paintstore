using Microsoft.AspNetCore.Mvc;

using PaintStore.Models.DTOs;
using PaintStore.Models.Interfaces.Services;

namespace PaintStore.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class UserController : ControllerBase
    {

        private readonly IUserService _service;

        private ILogger<UserController> _logger;


        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            _logger.LogInformation("Create User: Received request");

            var userResponse = _service.CreateUser(createUserRequest);

            _logger.LogInformation("Created User: User created with id");
            return Created($"/api/users/{userResponse.Id}", userResponse);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsers()
        {
            List<UserResponse> users = _service.GetUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserById(int id)
        {
            var user = _service.GetUserById(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateUser(int id, [FromBody] UpdateUserRequest updateUserRequest)
        {

            var updatedUser = _service.UpdateUser(id, updateUserRequest);

            if (updatedUser == null) return NotFound();

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteUser(int id)
        {

            var deletedUserResponse = _service.DeleteUser(id);

            if (deletedUserResponse == null) return NotFound();

            return Ok(deletedUserResponse);
        }

        // [HttpGet("GetUserByName/{name}")]
        // public IActionResult GetUserByName(string name)
        // {
        //     List<User> users = [.. _dbContext.Users];

        //     if (users.Any(user => user.Name == name))
        //     {
        //         return Ok(users.Select(user => user.Name == name));
        //     }

        //     return NotFound();
        // }

        // [HttpGet("GetUsersByEmail/{email}")]
        // public IActionResult GetUserByEmail(string email)
        // {
        //     List<User> users = [.. _dbContext.Users];

        //     if (users.Any(user => user.Email == email))
        //     {
        //         return Ok(users.Select(user => user.Email == email));
        //     }

        //     return NotFound();
        // }
    }
}
