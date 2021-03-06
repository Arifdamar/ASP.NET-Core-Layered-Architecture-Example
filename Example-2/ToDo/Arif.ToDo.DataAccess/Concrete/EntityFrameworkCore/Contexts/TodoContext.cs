﻿using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using Arif.ToDo.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class TodoContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\ProjectsV13;database=ToDo;integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new UrgencyMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Urgency> Urgencies { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }
}
