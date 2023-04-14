using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Suppliers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Carmodel { get; set; }
        
        public ISet<Products> products { get; set; }

        public Suppliers()
        {
            products = new HashSet<Products>();
        }
    }
}
