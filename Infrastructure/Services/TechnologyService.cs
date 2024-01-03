using Domain.DTOs;
using Domain.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TechnologyService
    {
        //private readonly ITechnologyRepository _technologyRepository;

        //public TechnologyService(ITechnologyRepository technologyRepository)
        //{
        //    _technologyRepository = technologyRepository;
        //}

        //public async Task<bool> DeleteProject(Guid id)
        //{
        //    var technology = await _technologyRepository.GetAsync(id);
        //    if (technology == null)
        //    {
        //        throw new HttpStatusException(HttpStatusCode.NotFound, "Project not found");
        //    }
        //    _technologyRepository.Delete(technology);
        //    await _technologyRepository.SaveAsync();
        //    return true;
        //}

        //public Project GetProjectById(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Project> GetProjectByIdAsync(Guid id) => await _technologyRepository.GetProjectByIdAsync(id);

        //public IQueryable<Project> GetProjects() => _technologyRepository.GetProjects();


        //public void InsertProject(Project project)
        //{
        //    if (project != null)
        //    {
        //        _technologyRepository.InsertProject(project);
        //        _technologyRepository.Save();
        //    }
        //    throw new HttpStatusException(HttpStatusCode.BadRequest, "Project cannot be null");
        //}

        //public async System.Threading.Tasks.Task<bool> InsertProjectAsync(Project project)
        //{
        //    if (project != null)
        //    {
        //        await _technologyRepository.InsertProjectAsync(project);
        //        await _technologyRepository.SaveAsync();
        //        return true;
        //    }
        //    throw new HttpStatusException(HttpStatusCode.BadRequest, "Project cannot be null");
        //}

        //public async Task<bool> UpdateProject(Project project)
        //{
        //    if (project != null)
        //    {
        //        _technologyRepository.UpdateProject(project);
        //        await _technologyRepository.SaveAsync();
        //        return true;
        //    }
        //    throw new HttpStatusException(HttpStatusCode.BadRequest, "Project cannot be null");
        //}
    }
}
