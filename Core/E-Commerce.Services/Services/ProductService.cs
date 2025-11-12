
using E_Commerce.Domain.Entites.Products;
using E_Commerce.Services.Exceptions;
using E_Commerce.Services.Specification;
using E_Commerce.ServicesAbstraction.Common;
using E_Commerce.Shared.DataTransferObject;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Services
{
    internal class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken = default)
        {
            var brands = await unitOfWork.GetRepository<ProductBrand, int>()
                .GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<BrandResponse>>(brands);
        }

        public async Task<Result<ProductResponse?>> GetByIdAsync(int Id, CancellationToken cancellationToken = default)
        {
            var spec = new ProductBrandTypeSpecification(Id);
            var product = await unitOfWork.GetRepository<Product, int>()
                .GetAsync(spec, cancellationToken);
               
            return product is null ? Error.Product.NotFound : mapper.Map<Product,ProductResponse>(product);
        }

        public async Task<PaginatedResult<ProductResponse>> GetProductsAsync(ProductQueryParameters parameters, CancellationToken cancellationToken = default)
        {
            var spec = new ProductBrandTypeSpecification(parameters);
            var data = await unitOfWork.GetRepository<Product, int>()
                                .GetAllAsync(spec, cancellationToken);
            var totalCount = await unitOfWork.GetRepository<Product,int>()
                             .CountAsync(new ProductCountSpecification(parameters) , cancellationToken);
            var products = mapper.Map<IEnumerable<ProductResponse>>(data);
            return new PaginatedResult<ProductResponse>(parameters.PageIndex, products.Count(), totalCount, products.ToList());
        }

        public async Task<IEnumerable<TypeResponse>> GetTypesAsync(CancellationToken cancellationToken = default)
        {
            var types = await unitOfWork.GetRepository<ProductType, int>()
                            .GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<TypeResponse>>(types);
        }
    }
}
