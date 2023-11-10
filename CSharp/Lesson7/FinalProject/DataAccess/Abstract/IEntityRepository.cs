using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // class => Referans tip olabilir, mesela int yazamaz demek 
        // ya da IEntity'den implemente olan demek

        List<T> GetAll(Expression<Func<T, bool>> filter = null); // delege
        T Get(Expression<Func<T, bool>> filter); // tek data getirmek için
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
