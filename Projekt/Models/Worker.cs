using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Postalcode { get; set; }

        public ISet<Departments> departments { get; set; }
        public Worker() 
        { 
            departments = new HashSet<Departments>();
            shifts = new HashSet<Shifts>();
        
        }
        public ISet<Shifts> shifts { get; set; }

    }
}
