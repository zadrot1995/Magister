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
    public class TaskStageRepository : ITaskStageRepository, IDisposable
    {
        private bool disposed = false;

        private readonly ApplicationDbContext _context;

        public TaskStageRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void DeleteTaskStage(TaskStage taskStage)
        {
            _context.TaskStages.Remove(taskStage);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public TaskStage GetTaskStageById(Guid id)
        {
            return _context.TaskStages.Find(id);
        }
        public async Task<TaskStage> GetTaskStageByIdAsync(Guid id)
        {
            return await _context.TaskStages.FindAsync(id);
        }

        public IEnumerable<TaskStage> GetTaskStages()
        {
            return _context.TaskStages;
        }

        public void InsertTaskStage(TaskStage taskStage)
        {
            _context.TaskStages.Add(taskStage);
        }
        public async Task<bool> InsertTaskStageAsync(TaskStage taskStage)
        {
            await _context.TaskStages.AddAsync(taskStage);
            return true;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async void SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateTaskStage(TaskStage taskStage)
        {
            _context.Entry(taskStage).State = EntityState.Modified;
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
