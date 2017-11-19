using System;
using System.Linq;

namespace Interfaces
{
    public interface IBaseService<TEntity> : IDisposable where TEntity : class
    {
        TEntity GetById(params object[] keys);

        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(params object[] keys);
        void Delete(TEntity entity);

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Where(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();
    }
}
