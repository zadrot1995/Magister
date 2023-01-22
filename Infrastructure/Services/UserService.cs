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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "User not found");
            }
            _userRepository.DeleteUser(user);
            await _userRepository.SaveAsync();
            return true;
        }

        public User GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByIdAsync(Guid id) => await _userRepository.GetUserByIdAsync(id);

        public IEnumerable<User> GetUsers() => _userRepository.GetUsers();

        public void InsertUser(User user)
        {
            if (user != null)
            {
                _userRepository.InsertUser(user);
                _userRepository.Save();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "User cannot be null");
        }

        public async System.Threading.Tasks.Task InsertUserAsync(User user)
        {
            if (user != null)
            {
                await _userRepository.InsertUserAsync(user);
                await _userRepository.SaveAsync();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "User cannot be null");
        }

        public async void UpdateUser(User user)
        {
            if (user != null)
            {
                _userRepository.UpdateUser(user);
                await _userRepository.SaveAsync();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "User cannot be null");
        }
    }
}
