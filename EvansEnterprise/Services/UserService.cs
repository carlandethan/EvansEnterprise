using EvansEnterprise.Data;
using EvansEnterprise.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvansEnterprise.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Jwt _jwt;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<Jwt> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }
    }
}
