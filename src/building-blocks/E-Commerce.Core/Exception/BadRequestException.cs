using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Exception
{
    public  class BadRequestException:System.Exception
    {

        public BadRequestException(string message) : base(message)
        {
        }
        public BadRequestException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
        public BadRequestException(string message, System.Exception innerException, string errorCode) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
        public string ErrorCode { get; set; } = string.Empty;

    }
}
