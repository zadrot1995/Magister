using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITeamService
    {
        IEnumerable<Team> GetCompanies();
        Team GetTeamById(Guid id);
        Task<Team> GetTeamByIdAsync(Guid id);
        void InsertTeam(Team team);
        void InsertTeamAsync(Team team);
        Task<bool> DeleteTeam(Guid id);
        void UpdateTeam(Team team);
    }
}
