using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DataTransferObject
{
    public record PaginatedResult<TResult>(int PageIndex , int PageCount,int TotalCount , ICollection<TResult> Data);
    
}
