using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITeamRepository : IDisposable
    {
        IEnumerable<Team> GetTeams();
        Team GetTeamById(Guid id);
        void InsertTeam(Team team);
        void DeleteTeam(Team team);
        void UpdateTeam(Team team);
        void Save();
    }
}
