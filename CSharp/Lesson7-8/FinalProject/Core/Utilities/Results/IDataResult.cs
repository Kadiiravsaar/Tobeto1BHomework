using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    /// <summary>
    ///  veri ile birlikte işlem sonucu da mesaj da içerecek
    /// Hangi tipi döndüreceğini bana söyle
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public interface IDataResult<T> : IResult // ırsult yazmamın sebebi bidaha success ve message yazmayayım
    {
        T Data { get; }
    }
}
