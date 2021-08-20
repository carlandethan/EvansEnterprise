using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EvansEnterprise.Data
{
    public class ToDoItemContext : IdentityDbContext
    {
        public ToDoItemContext (DbContextOptions<ToDoItemContext> options)
            : base(options)
        {
        }

        public DbSet<Model.ToDoItem> ToDoItem { get; set; }
    }
}
