using EvansEnterprise.gRPCService;
using EvansEnterprise.gRPCService.Protos;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EvansEnterprise.gRPCService.Services
{
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override Task<ProfileReply> UserProfile(ProfileRequest request, ServerCallContext context)
        {

            return Task.FromResult(new ProfileReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<AuthorizationRespond> Login(TokenRequest request, ServerCallContext context)
        {
            
            return Task.FromResult(new AuthorizationRespond
            {
                IsAuthenticated = true,
                Email = "carlandethan@gmail.com",
                MessageId = "",
                Token = ""
 

            }); ; ; 
        }

    }
}
