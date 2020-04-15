using MyFinances.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyFinances.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        bool Insert(ref TEntity entity);
        bool Update(TEntity entity);
        bool DeleteUser(int id);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
    }
}
