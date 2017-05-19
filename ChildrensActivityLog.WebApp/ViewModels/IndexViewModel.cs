using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrensActivityLog.WebApp.ViewModels
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
