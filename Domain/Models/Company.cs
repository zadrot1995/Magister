﻿using Domain.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Company : Entity
    {
        public string? OwnerId { get; set; }
        public string Name { get; set; }
        public IEnumerable<User>? Workers { get; set; }
        public IEnumerable<Team>? Teams { get; set; }
        public IEnumerable<Project>? Projects { get; set; }
        public IEnumerable<Technology>? Technologies { get; set;}
        public IEnumerable<Option>? Category { get; set; }
        public IEnumerable<Option>? Type { get; set; }
        public IEnumerable<Option>? ManagementSystem { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }

    }
}
