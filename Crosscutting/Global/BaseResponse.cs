using System;
using System.Collections.Generic;
using System.Text;

namespace Crosscutting.Global
{
    public class BaseResponse<T>
    {
        public int CodigoDeError { get; set; }
        public string Mensaje { get; set; }
        public T Response { get; set; }
    }
}
