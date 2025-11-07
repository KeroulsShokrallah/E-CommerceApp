using E_Commerce.Domain.Entites.Basket;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    internal class BasketRepository(IConnectionMultiplexer multiplexer)
        : IBasketRepository
    {
        private readonly IDatabase _database = multiplexer.GetDatabase();
        public async Task<CustomerBasket> CreateOrUpdateAsync(CustomerBasket Basket, TimeSpan? TTL = null)
        {
           var json = JsonSerializer.Serialize(Basket);
            await _database.StringSetAsync(Basket.Id, json,TTL??TimeSpan.FromDays(7));
            return await GetByIdAsync(Basket.Id);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<CustomerBasket?> GetByIdAsync(string id)
        {
            var json = await _database.StringGetAsync(id);
            if (json.IsNullOrEmpty)
            {
                 return null;
            }
               

            return JsonSerializer.Deserialize<CustomerBasket>(json!);
        }
    }
}
