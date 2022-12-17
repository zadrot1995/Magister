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
    public class TeamRepository : ITeamRepository, IDisposable
    {
        private bool disposed = false;

        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void DeleteTeam(Team team)
        {
            _context.Teams.Remove(team);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Team GetTeamById(Guid id)
        {
            return _context.Teams.Find(id);
        }

        public IEnumerable<Team> GetTeams()
        {
            return _context.Teams;
        }

        public void InsertTeam(Team team)
        {
            _context.Teams.Add(team);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateTeam(Team team)
        {
            _context.Entry(team).State = EntityState.Modified;
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
