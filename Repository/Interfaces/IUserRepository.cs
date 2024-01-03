using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserById(Guid id);
        Task<User> GetUserByIdAsync(Guid id);
        void InsertUser(User user);
        System.Threading.Tasks.Task InsertUserAsync(User user);
        void DeleteUser(User user);
        Task<User> UpdateUser(User user);
        void Save();
        System.Threading.Tasks.Task SaveAsync();
    }
}
