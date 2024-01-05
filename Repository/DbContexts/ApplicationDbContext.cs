﻿using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Domain.Models.Task> Tasks { get; set; }
        public DbSet<TaskStage> TaskStages { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Option> Options { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserSkills)
            .WithMany(e => e.Users);

            modelBuilder.Entity<Company>()
            .HasMany(e => e.Category)
            .WithOne(e => e.Category);

            modelBuilder.Entity<Company>()
           .HasMany(e => e.Type)
           .WithOne(e => e.Type);

            modelBuilder.Entity<Company>()
           .HasMany(e => e.ManagementSystem)
           .WithOne(e => e.ManagementSystem);

            modelBuilder.Entity<User>()
            .HasOne(u => u.Company)
            .WithMany(c => c.Workers);

            modelBuilder.Entity<Company>()
        .HasOne(c => c.Owner)      // One Company has one Owner (User)
        .WithOne(u => u.OwnCompany)   // One User belongs to one Company
        .HasForeignKey<Company>(u => u.OwnerId); // Foreign key in User
        }

    }

}
