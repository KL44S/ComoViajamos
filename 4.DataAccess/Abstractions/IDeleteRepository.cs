using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstractions
{
    public interface IDeleteRepository<T>
    {
        void DeleteByConditions(Expression<Func<T, bool>> expression);
    }
}
