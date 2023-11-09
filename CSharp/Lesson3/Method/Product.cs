using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Lesson._3
{
    public class Product // ürünü anlatan veri tipi
    {
        // Property => Özellik
        public int Id { get; set; } 
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

    }
}
