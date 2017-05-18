using ChildrensActivityLog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrensActivityLog.WebApp.Models
{
    public class SleepingPeriodForCreationDto
    {
        public int Id { get; set; }
        public int ChildId { get; set; }
        public Child Child { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public enum TypeOfSleepingPeriods { light, alright, deep }
        public TypeOfSleepingPeriods TypeOfSleepingPeriod { get; set; }
    }
}
