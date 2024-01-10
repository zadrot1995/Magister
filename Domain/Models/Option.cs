using Domain.Abstract;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Option: Entity
    {
        public string? Text { get; set; }
        public OptionContextType OptionContext { get; set; }
        
        public Guid? CategoryId { get; set; }
        [JsonIgnore]
        public IEnumerable<Company>? Category { get; set; }

        public Guid? ManagementSystemId { get; set; }
        [JsonIgnore]
        public IEnumerable<Company>? ManagementSystem{ get; set; }

        public Guid? TypeId { get; set; }
        [JsonIgnore]
        public IEnumerable<Company>? Type { get; set; }

    }
}
