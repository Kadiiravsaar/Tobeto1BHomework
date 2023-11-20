using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        /// <summary>
        /// ister data ve mesaj ver
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        /// <summary>
        /// ister sadece data ver
        /// </summary>
        /// <param name="data"></param>
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        /// <summary>
        /// istersen sadece mesaj ver
        /// </summary>
        /// <param name="message"></param>
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        /// <summary>
        /// istersen bir şey verme
        /// </summary>
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
