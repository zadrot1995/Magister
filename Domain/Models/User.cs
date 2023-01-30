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
        public string? FullName { get; set; }
        public UserRoles? Role { get; set; }
        public IEnumerable<UserSkill>? UserSkills { get; set; }
        public int Rate { get; set; }
        public string? Description { get; set; }
        public string? CVUrl { get; set; }
    }
}
