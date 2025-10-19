using E_Commerce.Domain.Entites.Products;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace E_Commerce.Services.MappingProfiler
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductResponse>()
                .ForMember(d=>d.Brand,
                                  o=>o.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(d=>d.Type,
                                  o=>o.MapFrom(s=>s.ProductType.Name))
                .ForMember(d => d.PictureUrl,
                                  o => o.MapFrom<ProductPicturalUrlResolver>());
            CreateMap<ProductBrand, BrandResponse>();
            CreateMap<ProductType,TypeResponse>();
        }
    }
}

internal class ProductPicturalUrlResolver(IConfiguration configuration)
    : IValueResolver<Product, ProductResponse, string>
{
    public string Resolve(Product source, ProductResponse destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrWhiteSpace(source.PictureUrl))
            return null;
        return $"{configuration["BaseUrl"]}{source.PictureUrl}";
    }
}