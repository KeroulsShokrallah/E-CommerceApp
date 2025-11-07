using E_Commerce.ServicesAbstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.API.Attributes
{
    internal class RedisCashAttributes(int durationInMinute = 2)
        : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cashService = context.HttpContext.RequestServices.GetRequiredService<ICashService>();
            var key = GenerateCashKey(context.HttpContext.Request);
            var CashValue = await cashService.GetAsync(key);

            if(CashValue != null)
            {
                context.Result = new ContentResult
                {
                    Content = CashValue,
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status200OK
                };
                return;
            }

            var actionExcutedContext =await  next.Invoke();
            var result = actionExcutedContext.Result;
            if(result is OkObjectResult okResult)
            {
                await cashService.SetAsync(key, okResult.Value!,
                    TimeSpan.FromMinutes(durationInMinute));
            }



        }









        private static string GenerateCashKey(HttpRequest request)
        {
            var sb = new StringBuilder();
            foreach (var kvp in request.Query.OrderBy(q => q.Key))
            { 

                sb.Append($"{kvp.Key}-{kvp.Value}-");
            }
            return sb.ToString().Trim('-');
        }
    }
}
