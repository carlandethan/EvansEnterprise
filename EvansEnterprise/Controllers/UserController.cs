using EvansEnterprise.Model;
using EvansEnterprise.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EvansEnterprise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterUser model)
        {

             var result = await _userService.RegisterAsync(model);
             return Ok(result);

        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(TokenRequest model)
        {
            var result = await _userService.GetTokenAsync(model);
            return Ok(result);
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync(AddRole model)
        {
            var result = await _userService.AddRoleAsync(model);
            return Ok(result);
        }
    }
}
