using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Team : Entity
    {
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
        public User Leader { get; set; }
    }
}
