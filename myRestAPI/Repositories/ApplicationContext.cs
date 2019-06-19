using Microsoft.EntityFrameworkCore;
using myRestAPI.Models;

namespace myRestAPI
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Assignee> Assignees { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
    }
}
