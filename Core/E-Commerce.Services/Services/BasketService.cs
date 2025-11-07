using E_Commerce.Domain.Entites.Basket;
using E_Commerce.Shared.DataTransferObject.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Services
{
    public class BasketService(IBasketRepository basketRepository , IMapper mapper)
        : IBasketService
    {
        public async Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO BasketDTO)
        {
            var basket = mapper.Map<CustomerBasket>(BasketDTO);
            var updatedBasket = await basketRepository.CreateOrUpdateAsync(basket);
            return mapper.Map<CustomerBasketDTO>(updatedBasket);
        }

        public  Task DeleteAsync(string id)
        {
           return   basketRepository.DeleteAsync(id);
        }

        public async Task<CustomerBasketDTO> GetByIdAsync(string id)
        {
            var basket = await basketRepository.GetByIdAsync(id);
            return mapper.Map<CustomerBasketDTO>(basket);
        }
    }
}
