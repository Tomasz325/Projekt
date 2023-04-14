using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }

        public ISet<Suppliers> suppliers { get; set; }
        public ISet<Departments> departments { get; set; }
        public Products() 
        {
            suppliers = new HashSet<Suppliers>();
            departments = new HashSet<Departments>();
        }
        
    }
    
}

