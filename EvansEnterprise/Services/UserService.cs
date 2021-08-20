using EvansEnterprise.Constants;
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

        public async Task<string> RegisterAsync(RegisterUser register)
        {
            var user = new ApplicationUser
            {
                UserName = register.Username,
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName
            };

            var userWithSameEmail = await _userManager.FindByEmailAsync(register.Email);

            if (userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Authorization.default_role.ToString());
                    return $"User Registered with username {user.UserName}";
                }
                else
                {
                    string errorMassage = "";

                    foreach(IdentityError error in result.Errors)
                    {
                        errorMassage += error.Description + "  ";
                    } 

                    return $"User Registered encounter error username {errorMassage}";
                }
            }
            else
            {
                return $"Email {user.Email } is already registered.";
            }
        }
    }
}
