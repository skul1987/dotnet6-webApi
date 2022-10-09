using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class EmployeeDataContext : DbContext
    {
        public EmployeeDataContext()
        {
        }

        public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options) : base(options)
        {            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("A FALLBACK CONNECTION STRING");
            }
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
        }

        public DbSet<Employee> Employees {get; set;}
        public DbSet<User> Users {get; set;}

    }
}