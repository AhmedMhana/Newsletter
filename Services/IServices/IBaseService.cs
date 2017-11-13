using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
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
