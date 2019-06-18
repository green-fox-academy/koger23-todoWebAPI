using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
