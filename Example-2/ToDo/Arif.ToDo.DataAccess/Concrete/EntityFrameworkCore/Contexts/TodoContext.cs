using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using Arif.ToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class TodoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\ProjectsV13;database=ToDo;integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new WorkMap());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Work> Works { get; set; }
    }
}
