using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.Entities.Concrete
{
    public class Cart
    {
        public Cart()
        {
            Cartlines= new List<CartLine>();
        }
        public List<CartLine> Cartlines { get; set; }

        public decimal Total
        {
            get { return Cartlines.Sum(c => c.Product.UnitPrice * c.Quantity); }

        }
    }
}
