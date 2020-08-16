using Microsoft.AspNetCore.Mvc;
using Sample.API.Filters;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class AccountController : ControllerBase
    {
        [HttpGet("Secret")]
        public IActionResult GetSecret()
        {
            return Ok("I Have no Secret");
        }
    }
}