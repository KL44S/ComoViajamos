using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstractions
{
    public interface IRepository<T> : IGetRepository<T>, IDeleteRepository<T>, ISaveRepository<T>
    {
    }
}
