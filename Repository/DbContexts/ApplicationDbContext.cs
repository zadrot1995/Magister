using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DbContexts
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Domain.Models.Task> Tasks { get; set; }
        public DbSet<TaskStage> TaskStages { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
