using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.DbContexts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update(User user)
        {
            var result = await _userService.UpdateUser(user);
            return Ok(result);
        }

        [HttpGet("get-company/{userId}")]
        public async Task<ActionResult<Company>> GetUserCompany(string userId)
        {
            var result = await _userService.GetUserCompanyAsync(userId);
            if(result == null)
            {
                return NotFound();
            }
            foreach(var worker in result.Workers)
            {
                worker.Company = null;
            }
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetById(string userId)
        {
            var result = _userService.GetUserByIdAsync(userId);
            return Ok(result);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var result = _userService.GetUsers();
            return Ok(result);
        }

    }
}
