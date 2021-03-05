using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message):this(success)
        {  //yukardaki this işlemini aşağıdaki const da çağırması için buraya success de yapabilirdik ama kod tekrar etmemesi için
            Message = message;
            // sadece getter koydukki sadece constructorda değistirebilsin istediği  gibi at koşturmasın
        }
        public Result(bool success)
        {
            Success = success;
            //mesaj yazmasa da olur
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
