using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer.Common.ApiResponse
{
    public class ErrorApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public int StatusCode { get; set; }
       
        public static ErrorApiResponse Fail(string message, int statusCode)
        {
            return new ErrorApiResponse
            {
                Success = false,
                Message = message,
                StatusCode = statusCode
            };
        }

    }
}
