using ChildrensActivityLog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrensActivityLog.WebApp.Models
{
    public class ChildForCreationDto
    {       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<SleepingPeriod> SleepingPeriods { get; set; }
        public ICollection<ChildrensPlayEvents> ChildrensPlayEvents { get; set; }
    }
}
