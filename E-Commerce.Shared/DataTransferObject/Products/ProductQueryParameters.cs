using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DataTransferObject.Products
{
    public class ProductQueryParameters
    {
        private const int MaxPageSize = 10;
        private const int DefaultPageSize = 5;
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public string? Search { get; set; }

        public ProductSortingOptions? sort { get; set; }

        public int pageSize = DefaultPageSize;
        public int PageSize
        {
            get => pageSize;
            set => pageSize = value > MaxPageSize ? MaxPageSize
                : value < DefaultPageSize ? DefaultPageSize : value;
        }

        public int PageIndex { get; set; } = 1;
    }
}

public enum ProductSortingOptions
{
    NameAscending = 1,
    NameDescending = 2,
    PriceAscending = 3,
    PriceDescending = 4,
}