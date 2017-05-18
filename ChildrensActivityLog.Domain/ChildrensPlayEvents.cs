using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChildrensActivityLog.Domain
{
    public class ChildrensPlayEvents
    {       
        public int ChildId { get; set; }
        public Child Child { get; set; }
        public int PlayEventId { get; set; }
        public PlayEvent PlayEvent { get; set; }
    }
}
