using Domain.DTOs;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<User> Login(LoginModel model)
        {
            var result =
                await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
                return user;
            }
            else
            {
                throw new HttpStatusException(HttpStatusCode.Unauthorized, "Uncorrect login or password");
            }
        }

        public async System.Threading.Tasks.Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<User> Register(RegisterModel model)
        {
            User user = new User { Email = model.Email, UserName = model.Email };
            // добавляем пользователя
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // установка куки
                await _signInManager.SignInAsync(user, false);
                return user;
            }
            else
            {
                var message = result.Errors.FirstOrDefault().Description;
                if (!string.IsNullOrEmpty(message))
                {
                    throw new HttpStatusException(HttpStatusCode.Unauthorized, message);
                }
                else
                {
                    throw new HttpStatusException(HttpStatusCode.InternalServerError, "Internal server error!");
                }
            }
        }

        public async System.Threading.Tasks.Task<User> GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(_signInManager.Context.User);
            if (user != null)
            {
                return user;
            }
            throw new HttpStatusException(HttpStatusCode.Unauthorized, "Unauthorized");
        }
    }
}
