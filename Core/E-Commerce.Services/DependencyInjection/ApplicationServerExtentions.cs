using E_Commerce.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.DependencyInjection
{
    public static class ApplicationServerExtentions
    {
        public static IServiceCollection AddApplicationsServices(this IServiceCollection services)
        {
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

    }
}
