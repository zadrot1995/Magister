﻿using Domain.Abstract;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectStages ProjectStages { get; set; }
        public IEnumerable<Task>? Tasks { get; set; }
        public IEnumerable<Team>? Teams { get; set; }
    }
}
