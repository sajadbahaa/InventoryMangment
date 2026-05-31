using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer.Common.Exceptions
{
    public class NotFoundException : AppException
    {
        public NotFoundException(string message, int statusCode=404) : base(message, statusCode)
        {

        }
    }
}
