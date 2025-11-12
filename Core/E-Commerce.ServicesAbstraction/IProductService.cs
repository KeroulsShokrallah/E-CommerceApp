using E_Commerce.Shared.DataTransferObject;
using E_Commerce.Shared.DataTransferObject.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ServicesAbstraction
{
    public interface IProductService
    {
        Task<Result<ProductResponse?>> GetByIdAsync(int Id, CancellationToken cancellationToken = default);
        Task<PaginatedResult<ProductResponse>> GetProductsAsync(ProductQueryParameters parameters, CancellationToken cancellationToken = default);
        Task<IEnumerable<TypeResponse>> GetTypesAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken = default);

    }
}
 