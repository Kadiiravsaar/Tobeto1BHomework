using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    public class TradesmanCreditManager : ICreditManager
    {
        public void Calculate()
        {
            Console.WriteLine("Tüccar kredisi hesaplandı");
        }
    }
}
