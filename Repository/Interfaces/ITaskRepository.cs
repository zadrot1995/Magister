using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITaskRepository : IDisposable
    {
        IEnumerable<Domain.Models.Task> GetTasks();
        Domain.Models.Task GetTaskById(Guid id);
        void InsertTask(Domain.Models.Task task);
        void DeleteTask(Domain.Models.Task task);
        void UpdateTask(Domain.Models.Task task);
        void Save();
    }
}
