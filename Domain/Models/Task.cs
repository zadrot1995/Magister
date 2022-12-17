using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Task : Entity
    {
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public User Creator { get; set; }
        public User AsignedUser { get; set; }
    }
}
