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
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> DeleteTask(Guid id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "Task not found");
            }
            _taskRepository.DeleteTask(task);
            await _taskRepository.SaveAsync();
            return true;
        }

        public Domain.Models.Task GetTaskById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Models.Task> GetTaskByIdAsync(Guid id) => await _taskRepository.GetTaskByIdAsync(id);

        public IEnumerable<Domain.Models.Task> GetTasks() => _taskRepository.GetTasks();

        public void InsertTask(Domain.Models.Task task)
        {
            if (task != null)
            {
                _taskRepository.InsertTask(task);
                _taskRepository.Save();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "Task cannot be null");
        }

        public async void InsertTaskAsync(Domain.Models.Task task)
        {
            if (task != null)
            {
                await _taskRepository.InsertTaskAsync(task);
                await _taskRepository.SaveAsync();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "Task cannot be null");
        }

        public async void UpdateTask(Domain.Models.Task task)
        {
            if (task != null)
            {
                _taskRepository.UpdateTask(task);
                await _taskRepository.SaveAsync();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "Task cannot be null");
        }
    }
}
