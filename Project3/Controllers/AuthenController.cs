using Microsoft.AspNetCore.Mvc;
using Project3.Entity.Dto;

namespace Project3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        [HttpPost("/registerUser")]
        public IActionResult RegisterUser([FromBody] RegisterUser registerUser)
        {
            return Ok();
        }

        [HttpPost("/loginUser")]
        public IActionResult Login([FromBody] LoginUser login)
        {
            return Ok();
        }
    }
}
