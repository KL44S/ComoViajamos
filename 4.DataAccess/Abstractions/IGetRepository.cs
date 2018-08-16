using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstractions
{
    public interface IGetRepository<T>
    {
        IList<T> GetAll();
        IList<T> GetAllByConditions(Expression<Func<T, bool>> expression);
    }
}
