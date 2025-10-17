using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DataTransferObject.Products
{
    public record ProductResponse(int Id, string Name, string Description, string PictureUrl,decimal Price, string Brand, string Type);
}
    
