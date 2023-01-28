using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<Domain.Models.Task> GetTasks();
        Domain.Models.Task GetTaskById(Guid id);
        Task<Domain.Models.Task> GetTaskByIdAsync(Guid id);
        void InsertTask(Domain.Models.Task task);
        void InsertTaskAsync(Domain.Models.Task task);
        Task<bool> DeleteTask(Guid id);
        void UpdateTask(Domain.Models.Task task);
        Task<bool> UpdateTaskStage(Guid taskId, Guid stageId);
        Task<bool> InsertTaskStage(Guid taskId, TaskStage stage);
    }
}
