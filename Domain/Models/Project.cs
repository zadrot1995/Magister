﻿using Domain.Abstract;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectStages ProjectStages { get; set; }
        public IEnumerable<Task>? Tasks { get; set; }
        public IEnumerable<User>? Team { get; set; }
        public IEnumerable<Technology>? Technologies { get; set; }
        public string? ImageUrl { get; set; }
        public string? Category { get; set; }
        public string? Type { get; set; }
        public string? ManagementSystem { get; set; }
        public string? CreatorId { get; set; }
        public Guid? CompanyId { get; set; }
        [JsonIgnore]
        public Company? Company { get; set; }
        
    }
}
