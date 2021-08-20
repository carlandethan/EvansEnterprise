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
            if(ModelState.IsValid)
            {

                var result = await _userService.RegisterAsync(model);
                return Ok(result);
            }

            return BadRequest(ModelState.Values);
        }
    }
}
