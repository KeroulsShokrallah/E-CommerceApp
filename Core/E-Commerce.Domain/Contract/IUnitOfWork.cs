using E_Commerce.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Contract
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() 
            where TEntity : Entity<TKey>;
    }
}
