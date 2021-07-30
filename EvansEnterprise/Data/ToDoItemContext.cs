using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EvansEnterprise.Model;

namespace EvansEnterprise.Data
{
    public class ToDoItemContext : DbContext
    {
        public ToDoItemContext (DbContextOptions<ToDoItemContext> options)
            : base(options)
        {
        }

        public DbSet<EvansEnterprise.Model.ToDoItem> ToDoItem { get; set; }
    }
}
