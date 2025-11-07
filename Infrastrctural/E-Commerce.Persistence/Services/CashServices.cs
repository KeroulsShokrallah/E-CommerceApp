using E_Commerce.ServicesAbstraction;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Services
{
    internal class CashServices(IConnectionMultiplexer multiplexer)
        : ICashService
    {
        private readonly IDatabase _database = multiplexer.GetDatabase();
        public async Task<string?> GetAsync(string key)
        {
            return await _database.StringGetAsync(key);

        }

        public async Task SetAsync(string key, object value, TimeSpan TTL)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
           var json = JsonSerializer.Serialize(value,options);
            await _database.StringSetAsync(key, json,TTL);
        }
    }
}
