using E_Commerce.ServicesAbstraction;
using E_Commerce.Shared.DataTransferObject.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Services
{
    internal class ProductService : IProductService
    {
        public Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse?> GetByIdAsync(int Id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductResponse>> GetProductsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TypeResponse>> GetTypesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
