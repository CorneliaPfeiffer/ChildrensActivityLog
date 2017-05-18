using ChildrensActivityLog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrensActivityLog.WebApp.Models
{
    public class ChildrensPlayEventsDto
    {
        public int Id { get; set; }
        public int ChildId { get; set; }
        public Child Child { get; set; }
        public int PlayEventId { get; set; }
        public PlayEvent PlayEvent { get; set; }
    }
}
