using Microsoft.AspNetCore.Mvc;
using UserService.Database.Entities;
using UserService.Repository;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => StatusCode(StatusCodes.Status200OK, await userRepository.GetAll());


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id) => StatusCode(StatusCodes.Status200OK, await userRepository.GetUser(id));


        [HttpPost]
        public async Task<IActionResult> Add([FromForm] User user)
        {
            bool isAdded = await userRepository.AddUser(user);
            if (isAdded)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
