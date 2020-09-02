using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.API.Services;

namespace Sample.API.Controllers
{
  
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IJwtService _service;
        public AccountController(IJwtService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpPost(Name = "Authenticate")]
        public IActionResult Authenticate([FromBody] UserViewModel model)
        {
            if (model.Email =="Admin@new.com" && model.Username == "Admin")
            {
                return Ok(_service.GetSecurityToken(model.Email, model.Username, "Admin"));
            }
            return Unauthorized();
        }

        [Authorize]
        [HttpGet]
        public IActionResult IsIamAuthorized() => Ok(new { Message = "You Are The Admin"});

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index() => Ok(new { Message = "We here" });


    }
}