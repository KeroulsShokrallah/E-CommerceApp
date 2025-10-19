﻿using E_Commerce.ServicesAbstraction;
using E_Commerce.Shared.DataTransferObject.Products;
using E_Commerce_.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.API.Controllers
{

    public class ProductsController(IProductService service) : ApiControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProducts(CancellationToken cancellationToken = default)
        {
            var respone = await service.GetProductsAsync(cancellationToken);
            return Ok(respone);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetById(int id, CancellationToken cancellationToken = default)
        {
            var respone = await service.GetByIdAsync(id, cancellationToken);
            return Ok(respone);
        }
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResponse>>> GetBrands(CancellationToken cancellationToken = default)
        {
            var respone = await service.GetBrandsAsync(cancellationToken);
            return Ok(respone);
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeResponse>>> GetTypes(CancellationToken cancellationToken = default)
        {
            var respone = await service.GetTypesAsync(cancellationToken);
            return Ok(respone);
        }
    }
}
