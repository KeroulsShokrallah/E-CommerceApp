using E_Commerce.Shared.DataTransferObject.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ServicesAbstraction
{
    public interface IBasketService
    {
        Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO BasketDTO);
        Task<CustomerBasketDTO> GetByIdAsync(string  id);
        Task DeleteAsync(string  id);
    }
}
