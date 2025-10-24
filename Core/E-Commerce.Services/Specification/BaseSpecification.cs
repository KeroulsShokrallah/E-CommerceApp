using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Specification
{
    internal abstract class BaseSpecification<TEntity> : ISpecification<TEntity> where TEntity : class
    {
        protected BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }
        public ICollection<Expression<Func<TEntity, object>>> includes { get; private set; } = [];

        public Expression<Func<TEntity, bool>> Criteria { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }

       public Expression<Func<TEntity, object>> OrderBy { get; private set; }



        protected void AddIcludes(Expression<Func<TEntity, object>> expression)
        {
            includes.Add(expression);
        }

        protected void  AddOrderBy(Expression<Func<TEntity, object>> expression)
        {
            OrderBy = expression;
        }
        protected void  AddOrderByDesc(Expression<Func<TEntity, object>> expression)
        {
            OrderByDesc = expression;
        }

        public int Skip { get; private set; }

        public int Take { get; private set; }

        public bool IsPaginated { get; private set; }


        public void ApplyPaginated(int pageSize , int pageIndex)
        {
            IsPaginated = true;

            Skip = (pageIndex-1)*pageSize;
            Take = pageSize;

        }
    }
}
