using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    /// <summary>
    /// Başarılı sonuç
    /// </summary>
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)
        {

        }

        /// <summary>
        ///  Mesaj vermek istemiyorum sadece başarılı gelsin
        ///  base'in tek parametreli olanı(success) gelecek 
        /// </summary>
        public SuccessResult() : base(true)
        {

        }
    }
}

