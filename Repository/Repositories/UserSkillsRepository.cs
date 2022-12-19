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
    internal class UserSkillsRepository : IUserSkillsRepository, IDisposable
    {
        private bool disposed = false;

        private readonly ApplicationDbContext _context;

        public UserSkillsRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void DeleteUserSkill(UserSkill userSkill)
        {
            _context.UserSkills.Remove(userSkill);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public UserSkill GetUserSkillById(Guid id)
        {
            return _context.UserSkills.Find(id);
        }
        public async Task<UserSkill> GetUserSkillByIdAsync(Guid id)
        {
            return await _context.UserSkills.FindAsync(id);
        }

        public IEnumerable<UserSkill> GetUserSkills()
        {
            return _context.UserSkills;
        }

        public void InsertUserSkill(UserSkill userSkill)
        {
            _context.UserSkills.Add(userSkill);
        }
        public async void InsertUserSkillAsync(UserSkill userSkill)
        {
            await _context.UserSkills.AddAsync(userSkill);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async void SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateUserSkill(UserSkill userSkill)
        {
            _context.Entry(userSkill).State = EntityState.Modified;
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
