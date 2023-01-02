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
        IEnumerable<Project> GetProjects();
        Project GetProjectById(Guid id);
        Task<Project> GetProjectByIdAsync(Guid id);
        void InsertProject(Project project);
        void InsertProjectAsync(Project project);
        Task<bool> DeleteProject(Guid id);
        void UpdateProject(Project project);
    }
}
