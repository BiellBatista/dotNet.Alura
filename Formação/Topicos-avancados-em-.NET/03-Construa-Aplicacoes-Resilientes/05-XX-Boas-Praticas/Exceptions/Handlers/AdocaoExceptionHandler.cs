using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace _05_XX_Boas_Praticas.Exceptions.Handlers;

public class AdocaoExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not AdocaoException)
        {
            return ValueTask.FromResult(false);
        }

        ProblemDetails problemDetails = new ProblemDetails
        {
            Title = "Houve um problema no processo de adoção!",
            Status = StatusCodes.Status400BadRequest,
            Detail = exception.Message
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;
        httpContext.Response.WriteAsJsonAsync(problemDetails);
        return ValueTask.FromResult(true);
    }
}