using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entites.Basket
{
    public class BasketItem
    {
           #nullable disable
        public string Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
