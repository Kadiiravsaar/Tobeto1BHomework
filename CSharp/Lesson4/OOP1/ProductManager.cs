using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class ProductManager
    {
        
        public void Add(Product product)
        {
            Console.WriteLine($"{product.ProductName} Added");
        }
        public void Update(Product product,int newUnitPrice)
        {
            Console.WriteLine($"{product.ProductName} - Old({product.UnitPrice}) new({newUnitPrice}) Updated");
        }
        public void Delete(Product product)
        {
            Console.WriteLine($"{product.ProductName} Deleted");
        }
    }
}
