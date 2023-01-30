using Domain.DTOs;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUser()
        {
            return Ok(_accountService.GetCurrentUser());
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.Register(model);
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _accountService.Login(model));
            }
            return BadRequest();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return Ok();
        }

    }
}
