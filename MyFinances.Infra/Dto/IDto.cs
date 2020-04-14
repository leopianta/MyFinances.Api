using MyFinances.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyFinances.Infra.Dto
{
    public abstract class IDto<EntityDomain, Dto> where EntityDomain : Entity where Dto : class
    {
        public abstract EntityDomain ConvertToDominio(Dto dto);
        public abstract Dto ConvertToDto(EntityDomain model);
        public abstract IEnumerable<EntityDomain> ConvertToListDominio(IEnumerable<Dto> listDto);
        public abstract Expression<Func<Dto, bool>> ConvertToExpressionDto(Expression<Func<EntityDomain, bool>> predicate);
    }
}
