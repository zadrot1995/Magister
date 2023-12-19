using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IProjectService
    {
        IQueryable<Project> GetProjects();
        Project GetProjectById(Guid id);
        Task<Project> GetProjectByIdAsync(Guid id);
        void InsertProject(Project project);
        System.Threading.Tasks.Task<bool> InsertProjectAsync(Project project);
        Task<bool> DeleteProject(Guid id);
        Task<bool> UpdateProject(Project project);
    }
}
