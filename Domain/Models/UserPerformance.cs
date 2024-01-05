using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserPerformance
    {
        public int WorkTime { get; set; }
        public int DayOffTime { get; set; }
        public int NotWorkTime { get; set; }
        public int Overtime { get; set; }
        public int SickLeaveTime { get; set; }
        public int TaskDone { get; set; }
        public int StoryPoints { get; set; }
        public int DayOff { get; set; }
        public int SickLeaves { get; set; }
        public int Reviews { get; set; }
    }
}
