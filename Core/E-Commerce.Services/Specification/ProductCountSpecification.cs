using E_Commerce.Domain.Entites.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Specification
{
    internal sealed class ProductCountSpecification(ProductQueryParameters parameters) 
        : BaseSpecification<Product>(CreateCriteria(parameters))
    {
        private static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters parameters)
        {
            return p => (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId.Value)
           && (!parameters.TypeId.HasValue || p.TypeId == parameters.TypeId.Value)
           && (string.IsNullOrWhiteSpace(parameters.Search) || p.Name.Contains(parameters.Search));
        }
    }
}
