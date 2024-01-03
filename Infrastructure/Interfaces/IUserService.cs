using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(Guid id);
        Task<User> GetUserByIdAsync(Guid id);
        void InsertUser(User company);
        System.Threading.Tasks.Task InsertUserAsync(User company);
        Task<bool> DeleteUser(Guid id);
        Task<User> UpdateUser(User company);
    }
}
