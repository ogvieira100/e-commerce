using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Exception
{
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
        {

            _logger.LogError(exception, "Ocorreu uma exceção: {Message}", exception.Message);

            var (statusCode, title) = exception switch
            {
                ArgumentNullException => (StatusCodes.Status400BadRequest, "Parâmetro obrigatório ausente"),
                FormatException => (StatusCodes.Status400BadRequest, "Formato inválido"),
                UnauthorizedAccessException => (StatusCodes.Status403Forbidden, "Acesso negado"),
                _ => (StatusCodes.Status500InternalServerError, "Erro no servidor")
            };

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
