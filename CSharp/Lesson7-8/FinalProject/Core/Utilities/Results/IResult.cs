using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    /// <summary>
    /// Temel void operasyonları için (içerisinde data olmayacak)
    /// </summary>
    public interface IResult
    {
        bool Success { get; } // sadece okunabilir - Başarılı mı başarısız mı
        string Message { get; } // bilgilendirme, Yönlendirme 
    }
}
