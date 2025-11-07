using E_Commerce.Persistence.Context;
using E_Commerce.Persistence.Initializers;
using E_Commerce.Persistence.Repositories;
using E_Commerce.Persistence.Services;
using E_Commerce.ServicesAbstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
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

            services.AddScoped<ICashService, CashServices>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddSingleton<IConnectionMultiplexer>(cfc =>
            {
                return ConnectionMultiplexer
                .Connect(configuration.GetConnectionString("RedisConnection"));
            });
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
