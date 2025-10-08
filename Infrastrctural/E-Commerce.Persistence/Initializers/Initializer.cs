
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Initializers
{
    internal class Initializer(ApplicationDbContext appDbContext) : IDbInitializer
    {
        public async Task InitializeAsync()
        {
			try
			{
				if((await appDbContext.Database.GetPendingMigrationsAsync()).Any())
				{
					await appDbContext.Database.MigrateAsync();
				}

				if(!appDbContext.ProductBrands.Any())
				{
					var BrandsData = await File.ReadAllTextAsync(@"../Infrastrctural/E-Commerce.Persistence/Context/DataSeed/brands.json");

                    // neglect PropertyNameCaseInsensitive
                    var options = new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true,
					};

					var Brand = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData,options);
					if (Brand != null && Brand.Any())
					{
						appDbContext.ProductBrands.AddRange(Brand);
					}
					await appDbContext.SaveChangesAsync();
				}

				if(!appDbContext.ProductTypes.Any())
				{
					var TypesData = await File.ReadAllTextAsync(@"../Infrastrctural/E-Commerce.Persistence/Context/DataSeed/type.json");
					var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
					if (Types != null && Types.Any())
					{

						appDbContext.ProductTypes.AddRange(Types);
					}
					await appDbContext.SaveChangesAsync();
				}

				if(!appDbContext.Products.Any())
				{
					var ProductsData = await File.ReadAllTextAsync(@"../Infrastrctural/E-Commerce.Persistence/Context/DataSeed/Products.json");
					var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
					if(Products != null && Products.Any())
					{
						appDbContext.Products.AddRange(Products);
					}
					await appDbContext.SaveChangesAsync();
				}

			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
