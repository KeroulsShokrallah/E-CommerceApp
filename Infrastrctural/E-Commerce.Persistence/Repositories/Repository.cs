using E_Commerce.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    internal class Repository<TEntity, Tkey>(ApplicationDbContext dbContext) : IRepository<TEntity, Tkey>
        where TEntity : Entity<Tkey>
    {
        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public async Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken)
        {
            return await dbContext.Set<TEntity>().ApplySpecification(specification).CountAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<TEntity>().ApplySpecification(specification).ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<TEntity>().ApplySpecification(specification).FirstOrDefaultAsync( cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(Tkey id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<TEntity>().FindAsync(id, cancellationToken);
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }
    }
}
