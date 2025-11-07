using E_Commerce.Domain.Entites.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Contract
{
    public interface IBasketRepository
    {
        Task<bool> DeleteAsync(string id);
        Task<CustomerBasket?> GetByIdAsync(string id);
        Task<CustomerBasket> CreateOrUpdateAsync(CustomerBasket Basket, TimeSpan? TTL =null );

    }
}
