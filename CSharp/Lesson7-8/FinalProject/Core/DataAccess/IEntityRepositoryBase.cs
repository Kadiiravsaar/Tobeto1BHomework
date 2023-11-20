using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{

    // Class: Referans Tip
    // IEntity : IEntity olabilir veya imlemente almış olabilir
    // new(): New'lenebilir olmalı
    public interface IEntityRepositoryBase<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> expression = null);
        T Get(Expression<Func<T, bool>> expression);
        void Add(T entitiy);
        void Update(T entity);
        void Delete(T entity);
    }
}
