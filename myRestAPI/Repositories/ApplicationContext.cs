using Microsoft.EntityFrameworkCore;
using myRestAPI.Models;
using myRestAPI.Models.User;
using System.Threading.Tasks;

namespace myRestAPI
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Assignee> Assignees { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
    }
}
