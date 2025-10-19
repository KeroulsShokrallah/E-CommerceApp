using E_Commerce.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    internal class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repository = [];
        public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : Entity<TKey>
        {
            var typeName = typeof(TEntity).Name;
            if (_repository.ContainsKey(typeName))
            {
                return (_repository[typeName] as IRepository<TEntity, TKey>);
            }
            var repo = new Repository<TEntity, TKey>(dbContext);
            _repository.Add(typeName, repo);
            return repo;
        }

        public async Task<int> SaveChangesAsync() => await dbContext.SaveChangesAsync();
    }
}
