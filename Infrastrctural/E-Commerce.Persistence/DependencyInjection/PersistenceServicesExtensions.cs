using E_Commerce.Persistence.Context;
using E_Commerce.Persistence.Initializers;
using E_Commerce.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.DependencyInjection
{
    public static class PersistenceServicesExtensions 
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connection = configuration.GetConnectionString("SQLConnection");
                options.UseSqlServer(connection);
            });
            services.AddScoped<IDbInitializer, Initializer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
