using Domain.Abstract;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; }
        public IEnumerable<UserSkill>? UserSkills { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }
        public string CVUrl { get; set; }
    }
}
