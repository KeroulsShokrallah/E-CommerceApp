﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DataTransferObject.Products
{
    public record ProductResponse()
    {
#nullable disable 

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }

        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
    }
}
    
