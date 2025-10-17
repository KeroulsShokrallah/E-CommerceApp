using E_Commerce.ServicesAbstraction;
using E_Commerce.Shared.DataTransferObject.Products;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce_.Web.Controllers
{
    //[ApiController]
    //[Route("api/[Controller]")]
    public class ProductController(IProductService service) : ApiControllerBase
    {
        #region

        //[Route("{id}")]
        //[HttpGet]
        //public ActionResult Get(int id)
        //{
        //    return Ok(new Product { Id = id});
        //}
        //[HttpGet]
        //public ActionResult GetAll()
        //{
        //    return Ok(new Product { });
        //}

        //[HttpPost]
        //public ActionResult Create(Product product)
        //{
        //    return Created();
        //}

        //[ HttpPut]
        //public ActionResult Update(Product product)
        //{
        //    return Created();
        //}

        //[HttpDelete]
        //public ActionResult Delete(Product product)
        //{
        //    return NoContent();
        //}
        #endregion

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProducts(CancellationToken cancellationToken = default)
        {
             var respone = await service.GetProductsAsync(cancellationToken);
            return Ok(respone);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetById(int id,CancellationToken cancellationToken = default)
        {
             var respone = await service.GetByIdAsync(id,cancellationToken);
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

//public class Product
//{
//    public int Id { get; set; } = 1;
//    public string Name { get; set; } = "product";
//}