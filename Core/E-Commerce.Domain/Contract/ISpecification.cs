﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Contract
{
    public interface ISpecification<TEntity> where TEntity : class 
    {
        ICollection<Expression<Func<TEntity,object>>> includes { get; }
        Expression<Func<TEntity, bool>> Criteria { get; }
        Expression<Func<TEntity, object>> OrderBy { get; }
        Expression<Func<TEntity, object>> OrderByDesc { get; }

        int Skip {  get; }
        int Take { get; }
        bool IsPaginated { get; }
    }
}
