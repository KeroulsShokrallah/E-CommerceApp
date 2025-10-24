using E_Commerce.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Contract
{
    public interface IRepository<TEntity,Tkey> where TEntity : Entity<Tkey>
    {
        public void Add(TEntity entity);
        public void Remove(TEntity entity);
        public void Update(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken=default);
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> specification,CancellationToken cancellationToken=default);
        Task<TEntity?> GetByIdAsync(Tkey id ,CancellationToken cancellationToken=default);
        Task<TEntity?> GetAsync(ISpecification<TEntity> specification ,CancellationToken cancellationToken=default);

        Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);

        
    }
}
