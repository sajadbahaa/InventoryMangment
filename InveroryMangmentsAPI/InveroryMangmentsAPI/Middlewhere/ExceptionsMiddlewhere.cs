using DTOsLayer.Common.ApiResponse;
using DTOsLayer.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace InveroryMangmentsAPI.Middlewhere
{
    public class ExceptionsMiddlewhere
    {
        private readonly RequestDelegate _next;
        public ExceptionsMiddlewhere(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            int statusCode = ex is AppException appException?appException.StatusCode: (int)HttpStatusCode.InternalServerError;
            ApiResponse response = ApiResponse.Fail(ex.Message, statusCode);
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

    }
}
