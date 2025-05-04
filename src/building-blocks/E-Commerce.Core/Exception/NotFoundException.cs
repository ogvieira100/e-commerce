using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Exception
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
        public NotFoundException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
        public NotFoundException(string message, System.Exception innerException, string errorCode) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
        public string ErrorCode { get; set; } = string.Empty;
    }
}
