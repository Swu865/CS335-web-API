using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using A1.Model;

namespace A1.Data
{
    public class StaffDbContext : DbContext
    {
        public StaffDbContext(DbContextOptions<StaffDbContext> options) : base(options) { }
        public DbSet<Staff> Staff { get; set; }

        public DbSet<Product> Product { get; set; }
        public DbSet<Comment> Comment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=StaffDatabase.sqlite");
            
        }

    }
}