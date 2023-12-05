using ResumeCraft.Domain.Entities.Base;
using System.Linq.Expressions;

namespace ResumeCraft.Domain.Repositories
{
    public interface IRepositoryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IComparable
    {
        void Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        void Edit(TEntity entityToUpdate);
        Task EditAsync(TEntity entityToUpdate);
        IList<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync();
        TEntity GetById(TKey id);
        Task<TEntity> GetByIdAsync(TKey id);
        int GetCount(Expression<Func<TEntity, bool>> filter = null);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);
        void Remove(Expression<Func<TEntity, bool>> filter);
        void Remove(TEntity entityToDelete);
        void Remove(TKey id);
        Task RemoveAsync(Expression<Func<TEntity, bool>> filter);
        Task RemoveAsync(TEntity entityToDelete);
        Task RemoveAsync(TKey id);
        Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetByIncludingAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> navigationPropertyPath);
        Task<TEntity> FindAsync(TKey id);
    }
}
