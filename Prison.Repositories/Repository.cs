using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Prison.Data;
using Prison.Models.Base;
using Prison.Repositories.Base;

namespace Prison.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PrisonContext _dbContext;
        private readonly DbSet<T> _modelDBSets;

        public Repository(PrisonContext dbContext)
        {
            _dbContext = dbContext;
            _modelDBSets = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _modelDBSets.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            _modelDBSets.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return _modelDBSets.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _modelDBSets.Where(predicate).ToListAsync();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _modelDBSets.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
