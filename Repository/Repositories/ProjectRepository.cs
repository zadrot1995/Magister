using Domain.Models;
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

        public ProjectRepository(ApplicationDbContext context)
        {
            this._context = context;
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
            return await _context.Projects.FindAsync(id);
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
            await _context.Projects.AddAsync(project);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateProject(Project project)
        {
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
