using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Models
{
    public class ServiceResopnse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public String Message { get; set; } = null;

    }
}
