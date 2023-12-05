using Microsoft.EntityFrameworkCore;
using ResumeCraft.Domain.UnitOfWorks;

namespace ResumeCraft.Persistence.UnitOfWorks.Base
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public virtual void Save() => _dbContext.SaveChanges();

        public virtual void Dispose() => _dbContext?.Dispose();
    }
}
