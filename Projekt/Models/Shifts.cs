using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Shifts
    {
        public int Id { get; set; } 
        public string Type { get; set; }
        public string Shours { get; set; }
        public string Fhours { get; set; }
        public ISet<Worker> workers { get; set; }
        public Shifts() { workers = new HashSet<Worker>(); }
        }
    }

