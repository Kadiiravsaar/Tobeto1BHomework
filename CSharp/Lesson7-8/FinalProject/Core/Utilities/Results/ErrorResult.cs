using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    /// <summary>
    /// Başarısız sonuç
    /// </summary>
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {

        }

        /// <summary>
        ///  Mesaj vermek istemiyorum sadece başarısız gelsin
        ///  base'in tek parametreli olanı gelecek 
        /// </summary>
        public ErrorResult() : base(false)
        {

        }
    }
}
