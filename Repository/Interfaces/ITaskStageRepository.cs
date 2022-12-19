using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    internal interface ITaskStageRepository : IDisposable
    {
        IEnumerable<TaskStage> GetTaskStages();
        TaskStage GetTaskStageById(Guid id);
        Task<TaskStage> GetTaskStageByIdAsync(Guid id);
        void InsertTaskStage(TaskStage taskStage);
        void InsertTaskStageAsync(TaskStage taskStage);
        void DeleteTaskStage(TaskStage taskStage);
        void UpdateTaskStage(TaskStage taskStage);
        void Save();
        void SaveAsync();

    }
}
