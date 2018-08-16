using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstractions
{
    public interface ISaveRepository<T>
    {
        void Save(T entity);
    }
}
