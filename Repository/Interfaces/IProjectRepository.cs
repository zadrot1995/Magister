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
        void InsertProject(Project project);
        void DeleteProject(Project project);
        void UpdateProject(Project project);
        void Save();
    }
}
