using EvansEnterprise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvansEnterprise.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterUser register);
    }
}
