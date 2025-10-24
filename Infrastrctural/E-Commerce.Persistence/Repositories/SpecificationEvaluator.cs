using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    internal static class SpecificationEvaluator 
    {
        public static IQueryable<TEntity> ApplySpecification<TEntity> (this IQueryable<TEntity> inputQuery ,
            ISpecification<TEntity> specification) where TEntity : class
        {
            var query = inputQuery;
            if(specification.Criteria != null) 
                query = query.Where(specification.Criteria);
            if(specification.OrderBy is not  null)
                query = query.OrderBy(specification.OrderBy);
            if(specification.OrderByDesc is not null)
                query = query.OrderByDescending(specification.OrderByDesc);
            if(specification.IsPaginated)
                query = query.Skip(specification.Skip)
                    .Take(specification.Take);

            query = specification.includes.Aggregate(query, (query, include)
                => query.Include(include));
            return query;
        

        }
    }
}
