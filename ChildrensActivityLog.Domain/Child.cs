using System;
using System.Collections.Generic;
using System.Text;

namespace ChildrensActivityLog.Domain
{
    public class Child
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<SleepingPeriod> SleepingPeriods { get; set; }
        public ICollection<ChildrensPlayEvents> ChildrensPlayEvents { get; set; }
    }
}
