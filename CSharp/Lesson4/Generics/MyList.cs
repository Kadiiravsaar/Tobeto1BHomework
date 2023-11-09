using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class MyList<T>
    {
        T[] items;
        public MyList()
        {
            items = new T[0]; // T[] items, class çağırıldığında newlendiğinde oluşurmak gerek diye ctor da yazdık
        }
        public void Add(T item)
        {
            T[] tempArray = items; // geçiçi diziye referansı atıyorum. Geçiçi olarak onu tempArraya verdim.
                                   // Referans no uçmasın diye

            items = new T[items.Length + 1]; // dizinin eleman sayısını bir arttırıyorum


            for (int i = 0; i < tempArray.Length; i++)
            {
                items[i] = tempArray[i];   // az önce verdiğim elemanları geri ver (sırasıyla)
            }

            items[items.Length - 1] = item; // 0 dan başladığı için -1 dedik

        }
    }
}
