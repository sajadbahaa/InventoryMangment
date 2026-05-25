using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer.Common.Exceptions
{
    public class ConflictException : AppException
    {
        public ConflictException(string message, int statusCode=409) : base(message, statusCode)
        {
        }

    }
}
