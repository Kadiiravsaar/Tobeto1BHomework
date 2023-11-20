using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        /// <summary>
        /// ister data ve mesaj ver
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }

        /// <summary>
        /// ister sadece data ver
        /// </summary>
        /// <param name="data"></param>
        public SuccessDataResult(T data) : base(data, true)
        {

        }

        /// <summary>
        /// istersen sadece mesaj ver
        /// </summary>
        /// <param name="message"></param>
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }

        /// <summary>
        /// istersen bir şey verme
        /// </summary>
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
