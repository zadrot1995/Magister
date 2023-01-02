using Domain.DTOs;
using Domain.Models;
using Infrastructure.Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<bool> DeleteProject(Guid id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "Project not found");
            }
            _projectRepository.DeleteProject(project);
            await _projectRepository.SaveAsync();
            return true;
        }

        public Project GetProjectById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetProjectByIdAsync(Guid id) => await _projectRepository.GetProjectByIdAsync(id);

        public IEnumerable<Project> GetProjects() => _projectRepository.GetProjects();

        public void InsertProject(Project project)
        {
            if (project != null)
            {
                _projectRepository.InsertProject(project);
                _projectRepository.Save();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "Project cannot be null");
        }

        public async void InsertProjectAsync(Project project)
        {
            if (project != null)
            {
                await _projectRepository.InsertProjectAsync(project);
                await _projectRepository.SaveAsync();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "Project cannot be null");
        }

        public async void UpdateProject(Project project)
        {
            if (project != null)
            {
                _projectRepository.UpdateProject(project);
                await _projectRepository.SaveAsync();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "Project cannot be null");
        }
    }
}
