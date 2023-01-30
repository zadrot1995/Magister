using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAccountService
    {
        Task<User> Register(RegisterModel model);
        Task<User> Login(LoginModel model);
        System.Threading.Tasks.Task Logout();
        System.Threading.Tasks.Task<User> GetCurrentUser();
    }
}
