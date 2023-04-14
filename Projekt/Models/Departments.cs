using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ISet<Worker> Workers { get; set; }
        [NotMapped]
        public int WorkerId { get; set; }
        public ISet<Products> products { get; set; }
        public Departments() 
        {
            Workers = new HashSet<Worker>();
            products = new HashSet<Products>();
        }

    }
}
