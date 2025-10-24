using E_Commerce.Domain.Entites.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Specification
{
    internal class ProductBrandTypeSpecification : BaseSpecification<Product>
    {
        public ProductBrandTypeSpecification(ProductQueryParameters parameters)
            : base(CreateCriteria(parameters))
        {
            AddIcludes(p => p.ProductBrand);    
            AddIcludes(p => p.ProductType);

            Sort(parameters);
            ApplyPaginated(parameters.PageSize,parameters.PageIndex);
        }

        private void Sort(ProductQueryParameters parameters)
        {
            switch (parameters.sort)
            {
                case ProductSortingOptions.NameAscending:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDescending:
                    AddOrderByDesc(p => p.Name);
                    break;
                case ProductSortingOptions.PriceAscending:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOptions.PriceDescending:
                    AddOrderByDesc(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;


            }
        }

        private static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters parameters)
        {
            return p => (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId.Value)
           && (!parameters.TypeId.HasValue || p.TypeId == parameters.TypeId.Value)
           && (string.IsNullOrWhiteSpace(parameters.Search) || p.Name.Contains(parameters.Search));
        }

        public ProductBrandTypeSpecification(int id) : base(p => p.Id == id)
        {
            AddIcludes(p => p.ProductBrand);
            AddIcludes(p => p.ProductType);
        }
    }
}
