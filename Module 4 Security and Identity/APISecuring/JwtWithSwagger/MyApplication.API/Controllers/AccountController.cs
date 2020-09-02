using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApplication.API.Services;

namespace MyApplication.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _identity;
        public AccountController(IIdentityService identity)
        {
            _identity = identity;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromForm] UserViewModel model)
        {
            if (model.Username == "Admin" && model.Password == "Admin@123")
            {
                return Ok(_identity.CreateSecurityToken(model.Username, "Admin@new.com", "Admin"));
            }
            return Unauthorized();
        }

        [Authorize(Roles ="Admin")]
        [HttpGet(Name = "Index")]
        public IActionResult Index() => Ok("I Am Admin");


    }
}