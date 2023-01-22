using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProjectRepository : IDisposable
    {
        IEnumerable<Project> GetProjects();
        Project GetProjectById(Guid id);
        Task<Project> GetProjectByIdAsync(Guid id);
        void InsertProject(Project project);
        System.Threading.Tasks.Task InsertProjectAsync(Project project);
        void DeleteProject(Project project);
        void UpdateProject(Project project);
        void Save();
        System.Threading.Tasks.Task SaveAsync();
    }
}
