using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Lesson._3
{
    // manager,service,dal, bunlar operasyon tutan sınıflardır
    public class BasketManager 
    {
        public void Add(Product product)
        {
            Console.WriteLine("Added to basket ! : " + product.Name);
        }
        public void AddTwo(string productName, string description, double price, int stock)
        {
            Console.WriteLine("Added to basket ! : " + productName);
        }

    }
}
