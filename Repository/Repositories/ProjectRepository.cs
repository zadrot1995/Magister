using Domain.Abstract;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.DbContexts;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProjectRepository : IProjectRepository, IDisposable
    {
        private bool disposed = false;

        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;


        public ProjectRepository(ApplicationDbContext context, UserManager<User> userManager)
        {
            this._context = context;

            _userManager = userManager;
        }

        public void DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Project GetProjectById(Guid id)
        {
            return _context.Projects.Find(id);
        }
        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            var result = await _context.Projects
                .Include(x => x.Team)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var test = result;
            return result;
        }

        public IQueryable<Project> GetProjects()
        {
            return _context.Projects;
        }

        public void InsertProject(Project project)
        {
            _context.Projects.Add(project);
        }

        public async System.Threading.Tasks.Task InsertProjectAsync(Project project)
        {
            var company = await _userManager.Users
                .Include(x => x.Company)
                .ThenInclude(x => x.Projects)
                .Where(x => x.Id == project.CreatorId).Select(x => x.Company).FirstOrDefaultAsync();
            if (company != null)
            {
                if(company.Projects == null)
                {
                    company.Projects = new List<Project>();
                }
                await _context.Projects.AddAsync(project);

                project.Company = company;
                project.CompanyId = company.Id;
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateProject(Project project)
        {
            var projectToUpdate = await _context.Projects
                .Include(x => x.Team)
                .Where(x => x.Id == project.Id)
                .FirstOrDefaultAsync();

            projectToUpdate.Name = project.Name;
            projectToUpdate.ManagementSystem = project.ManagementSystem;
            projectToUpdate.Category = project.Category;
            projectToUpdate.Type = project.Type;
            projectToUpdate.Description = project.Description;

            if (project.Team != null)
            {
                var team = await _context.Users.Where(x => project.Team.Select(y => y.Id).Contains(x.Id)).ToListAsync();
                projectToUpdate.Team = team;
            }
            _context.Entry(project).State = EntityState.Modified;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
