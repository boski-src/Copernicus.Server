using System;
using System.Net;
using System.Threading.Tasks;
using Copernicus.Common.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Copernicus.Common.Mvc.ErrorHandler
{
    public class ErrorHandlerMiddleware
    {
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var defaultCode = "UNKNOWN_ERROR";
            var defaultStatusCode = HttpStatusCode.BadRequest;
            var defaultMessage = "Internal Server Error.";

            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogDebug(exception, exception.Message);
                if (exception is CupernicusException)
                {
                    defaultCode = ((CupernicusException) exception).Code ?? "SERVICE_ERROR";
                    defaultMessage = exception.Message;
                }
                else
                {
                    _logger.LogError(exception, exception.Message);
                    defaultStatusCode = HttpStatusCode.ServiceUnavailable;
                }

                var error = new ErrorDto(defaultStatusCode, defaultCode, defaultMessage);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = error.Status;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
            }
        }
    }
}