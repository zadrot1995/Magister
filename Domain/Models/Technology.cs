﻿using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Technology : Entity
    {
        [JsonIgnore]
        public IEnumerable<Company>? Companies { get; set;  }
        public IEnumerable<Project>? Projects { get; set; }
        [JsonIgnore]
        public IEnumerable<User>? Users { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
