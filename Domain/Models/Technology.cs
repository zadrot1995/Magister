using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Technology : Entity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set;  }
        public IEnumerable<Project>? Projects { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
