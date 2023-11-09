using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class CoorporateCustomer : Customer  // tüzel
    {
        public string CompanyName { get; set; }
        public string TaxNo { get; set; } // vergi no
    }
}
