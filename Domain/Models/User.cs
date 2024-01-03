using Domain.Abstract;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public UserRoles? Role { get; set; }
        public IEnumerable<Technology>? UserSkills { get; set; }
        public int? Rate { get; set; }
        public string? Description { get; set; }
        public string? CVUrl { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string? Position { get; set; }
        public string? PhotoUrl { get; set; }

    }
}
