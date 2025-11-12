using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ServicesAbstraction.Common
{
 public   partial  class Error
    {
        public static class Product
        {
            public static Error NotFound => NotFound("Product Not Found", "Product With Spcefic Id Not Found");
        }
    }
}
