using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.DbContexts;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private bool disposed = false;

        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserRepository(ApplicationDbContext context, UserManager<User> userManager)
        {
            this._context = context;
            _userManager = userManager;
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public User GetUserById(Guid id)
        {
            return _context.Users.Find(id);
        }
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public void InsertUser(User user)
        {
            _context.Users.Add(user);
        }

        public async System.Threading.Tasks.Task InsertUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            // Get the existing student from the db
            var userToUpdate = await _userManager.Users.Include(x => x.UserSkills).Where(x => x.Id == user.Id).FirstOrDefaultAsync();

            // Update it with the values from the view model
            userToUpdate.UserName= user.UserName;
            userToUpdate.Email= user.Email;
            userToUpdate.Position= user.Position;
            userToUpdate.FirstName= user.FirstName;
            userToUpdate.LastName= user.LastName;
            userToUpdate.Description= user.Description;
            userToUpdate.PhotoUrl= user.PhotoUrl;
            if(user.UserSkills != null)
            {
                var skills = await _context.Technologies.Where(t => user.UserSkills.Select(x => x.Id).Contains(t.Id)).ToListAsync();
                userToUpdate.UserSkills = skills;
            }
            // Apply the changes if any to the db

            //await _userManager.UpdateAsync(userToUpdate);
            _context.Entry(userToUpdate).State = EntityState.Modified;

            return userToUpdate;
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
