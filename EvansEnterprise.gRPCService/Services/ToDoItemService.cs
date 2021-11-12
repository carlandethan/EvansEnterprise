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
    public class ToDoItemService : ToDoItem.ToDoItemBase
    {
        private readonly ILogger<ToDoItemService> _logger;
        public ToDoItemService(ILogger<ToDoItemService> logger)
        {
            _logger = logger;
        }
    }
}
