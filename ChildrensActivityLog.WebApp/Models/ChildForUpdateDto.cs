using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrensActivityLog.WebApp.Models
{
    public class ChildForUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
