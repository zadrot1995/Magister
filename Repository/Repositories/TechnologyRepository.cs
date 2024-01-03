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
    internal class TechnologyRepository : ITechnologyRepository, IDisposable
    {
        private bool disposed = false;

        private readonly ApplicationDbContext _context;

        public TechnologyRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Delete(Technology userSkill)
        {
            _context.Technologies.Remove(userSkill);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Technology Get(Guid id)
        {
            return _context.Technologies.Find(id);
        }
        public async Task<Technology> GetAsync(Guid id)
        {
            return await _context.Technologies.FindAsync(id);
        }

        public IEnumerable<Technology> Get()
        {
            return _context.Technologies;
        }

        public void Insert(Technology userSkill)
        {
            _context.Technologies.Add(userSkill);
        }
        public async void InsertAsync(Technology userSkill)
        {
            await _context.Technologies.AddAsync(userSkill);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async void SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Technology userSkill)
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
