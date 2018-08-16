using DataAccess.Abstractions;
using DataAccess.Factories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Implementations
{
    public class Repository<T> : IRepository<T>
    {
        private IRepository<T> _repository;

        public Repository(RepositoryFactory.Techs repositoryTech)
        {
            this._repository = RepositoryFactory.GetRepository<T>(repositoryTech);
        }

        public Repository()
        {
            this._repository = RepositoryFactory.GetRepository<T>();
        }

        public IList<T> GetAll()
        {
            return this._repository.GetAll();
        }

        public IList<T> GetAllByConditions(Expression<Func<T, bool>> expression)
        {
            return this._repository.GetAllByConditions(expression);
        }

        public void Save(T entity)
        {
            this._repository.Save(entity);
        }

        public void DeleteByConditions(Expression<Func<T, bool>> expression)
        {
            this._repository.DeleteByConditions(expression);
        }
    }
}
