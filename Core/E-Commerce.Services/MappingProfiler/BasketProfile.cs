using E_Commerce.Domain.Entites.Basket;
using E_Commerce.Shared.DataTransferObject.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.MappingProfiler
{
    internal class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketItem, BasketItemDTO>()
                .ReverseMap();
            CreateMap<CustomerBasket, CustomerBasketDTO>()
                .ReverseMap();
        }
    }
}
