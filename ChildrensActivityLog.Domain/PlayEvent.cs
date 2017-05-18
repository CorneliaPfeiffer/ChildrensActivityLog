using System;
using System.Collections.Generic;

namespace ChildrensActivityLog.Domain
{
    public class PlayEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<ChildrensPlayEvents> ChildrensPlayEvents { get; set; }
    }
}