using E_Commerce.Services.Exceptions;
using E_Commerce_.Web.MiddleWares;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_.Web.MiddleWares
{
    public class GlobalExceptionHandeler(RequestDelegate next , ILogger<GlobalExceptionHandeler> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
			try
            {
                await next.Invoke(context);
                await HandleNotFoundEndPointAsync(context);
            }
            catch (Exception ex)
			{
				logger.LogError("Something Went Wrong{Message}", ex.Message);

                var Problem = new ProblemDetails
                {
                    Title = "Error Processing The HTTP Request",
                    Detail = ex.Message,
                    Instance = context.Request.Path,
                    Status = ex switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    }

                };
				
				context.Response.StatusCode = Problem.Status.Value;
				await context.Response.WriteAsJsonAsync(Problem);
			}

        }

        private static async Task HandleNotFoundEndPointAsync(HttpContext context)
        {
            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var Problem = new ProblemDetails
                {
                    Title = "Error Processing The HTTP Request - End Point Not Found",
                    Detail = $"End Point {context.Request.Path} Not Found",
                    Instance = context.Request.Path,
                    Status = StatusCodes.Status404NotFound,

                };
                await context.Response.WriteAsJsonAsync(Problem);
            }
        }
    }

}

public static class GlobalExceptionHandelerExtensions
{
	public static WebApplication UseCustomExceptionHandler (this WebApplication app)
	{
		app.UseMiddleware<GlobalExceptionHandeler>();
		return app;
	}
}