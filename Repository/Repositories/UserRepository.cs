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
    public class UserRepository : IUserRepository, IDisposable
    {
        private bool disposed = false;

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            this._context = context;
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

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public void InsertUser(User user)
        {
            _context.Users.Add(user);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
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
