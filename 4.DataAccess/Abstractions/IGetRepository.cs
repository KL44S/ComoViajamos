using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Utils;

namespace DataAccess.Abstractions
{
    public interface IGetRepository<T>
    {
        IList<T> GetAll();
        IList<T> GetAllByConditions(Expression<Func<T, bool>> expression);
        IList<T> GetAllByConditionsAndSort<TKey>(Expression<Func<T, bool>> expression, Expression<Func<T, TKey>> sort, Constants.SortTypes sortType);
        T GetFirstByConditions(Expression<Func<T, bool>> expression);
        T GetFirstByConditionsAndSort<TKey>(Expression<Func<T, bool>> expression, Expression<Func<T, TKey>> sort, Constants.SortTypes sortType);
    }
}
