using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace issues.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool success { get; set; } = true;
        public string message { get; set; } = string.Empty;
    }
}