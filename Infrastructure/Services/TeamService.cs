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
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<bool> DeleteTeam(Guid id)
        {
            var team = await _teamRepository.GetTeamByIdAsync(id);
            if (team == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "Team not found");
            }
            _teamRepository.DeleteTeam(team);
            await _teamRepository.SaveAsync();
            return true;
        }

        public Team GetTeamById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Team> GetTeamByIdAsync(Guid id) => await _teamRepository.GetTeamByIdAsync(id);

        public IEnumerable<Team> GetCompanies() => _teamRepository.GetTeams();

        public void InsertTeam(Team team)
        {
            if (team != null)
            {
                _teamRepository.InsertTeam(team);
                _teamRepository.Save();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "Team cannot be null");
        }

        public async void InsertTeamAsync(Team team)
        {
            if (team != null)
            {
                await _teamRepository.InsertTeamAsync(team);
                await _teamRepository.SaveAsync();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "Team cannot be null");
        }

        public async void UpdateTeam(Team team)
        {
            if (team != null)
            {
                _teamRepository.UpdateTeam(team);
                await _teamRepository.SaveAsync();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "Team cannot be null");
        }
    }
}
