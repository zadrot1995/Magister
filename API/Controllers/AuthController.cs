using Azure.Core;
using Domain.Dtos;
using Domain.DTOs;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository.DbContexts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    { 
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(ApplicationDbContext context, ITokenService tokenService, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("getUser"), Authorize]
        public async Task<IActionResult> GetUser()
        {
            var role = this.User.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault().Value;
            var user = _context.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();

            return Ok(new { userName = this.User.Identity.Name, userType = role, id = user.Id });
        }

        [HttpGet("getUserRole"), Authorize]
        public async Task<IActionResult> GetUserRole()
        {
            var role = this.User.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault().Value;
            return Ok(new { userType = role });
        }



        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (loginModel is null)
            {
                return BadRequest("Invalid client request");
            }

            var user = await _userManager.Users
                .Include(u => u.UserSkills)
                .FirstOrDefaultAsync(u => u.UserName == loginModel.Login);


            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);


            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, loginModel.Login),
        };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            _context.SaveChanges();
            return Ok(new LoginResponse
            {
                Token = accessToken,
                RefreshToken = refreshToken,
                UserData = user
            });
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (model is null)
            {
                return BadRequest("Invalid client request");
            }

           
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Login),
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Login,
                UserName = model.Login,
                RefreshToken = refreshToken,
                RefreshTokenExpiryTime = DateTime.Now.AddDays(7)
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok(new AuthenticatedResponse
                    {
                        Token = accessToken,
                        RefreshToken = refreshToken
                    });
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine(ex);
            }
           
            return BadRequest();
        }
    }
}