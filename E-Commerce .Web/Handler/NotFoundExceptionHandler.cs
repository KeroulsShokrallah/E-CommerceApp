using E_Commerce.Services.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_.Web.Handler
{
    public class NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger ) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext Context, Exception ex, CancellationToken cancellationToken)
        {
            if (ex is NotFoundException notfound)
            {
                logger.LogError("Something Went Wrong{Message}", ex.Message);

                var Problem = new ProblemDetails
                {
                    Title = "Error Processing The HTTP Request",
                    Detail = notfound.Message,
                    Instance = Context.Request.Path,
                    Status = StatusCodes.Status400BadRequest
                };

                Context.Response.StatusCode = Problem.Status.Value;
                await  Context.Response.WriteAsJsonAsync(Problem);
                return true;

            }
            return false;
        }
    }
}
