using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }
        public string Message { get; } // readonly olanlar yani get'ler ctor da set edilebilir
        public Result(bool success, string message) : this(success) // tek parametreli olanı çalıştır
        {
            Message = message;
        }

        /// <summary>
        /// Mesaj yazmak istemiyorum. Sadece.başarılı mı başarısız mı o gelsin
        /// </summary>
        /// <param name="success"></param>
        public Result(bool success) // overloading deniyor
        {
            Success = success;

        }
    }
}
