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
    internal class TaskRepository : ITaskRepository, IDisposable
    {
        private bool disposed = false;

        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void DeleteTask(Domain.Models.Task task)
        {
            _context.Tasks.Remove(task);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Domain.Models.Task GetTaskById(Guid id)
        {
            return _context.Tasks.Find(id);
        }
        public async Task<Domain.Models.Task> GetTaskByIdAsync(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public IEnumerable<Domain.Models.Task> GetTasks()
        {
            return _context.Tasks;
        }

        public void InsertTask(Domain.Models.Task task)
        {
            _context.Tasks.Add(task);
        }

        public async void InsertTaskAsync(Domain.Models.Task task)
        {
            await _context.Tasks.AddAsync(task);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async void SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateTask(Domain.Models.Task task)
        {
            _context.Entry(task).State = EntityState.Modified;
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
