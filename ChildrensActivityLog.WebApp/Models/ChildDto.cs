using ChildrensActivityLog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrensActivityLog.WebApp.Models
{
    public class ChildDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<SleepingPeriodDto> SleepingPeriods { get; set; }
        public ICollection<ChildrensPlayEvents> ChildrensPlayEvents { get; set; }
    }
}
