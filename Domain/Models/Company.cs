using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public IEnumerable<User> Workers { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Project> Projects { get; set; }


    }
}
