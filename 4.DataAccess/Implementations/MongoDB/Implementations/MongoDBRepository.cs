using DataAccess.Abstractions;
using DataAccess.Implementations.MongoDB.Abstractions;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Utils;

namespace DataAccess.Implementations.MongoDB.Implementations
{
    public class MongoDBRepository<T> : IRepository<T>
    {
        private IMongoCollection<T> _mongoCollection;

        private String GetCollectionName()
        {
            String collectionName = typeof(T).Name;
            collectionName = Char.ToLowerInvariant(collectionName[0]) + collectionName.Substring(1);

            return collectionName;
        }

        private void RegisterAutoMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
            {
                BsonClassMap.RegisterClassMap<T>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);
                });
            }
        }

        private IQueryable<T> GetQueryableByConditions(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> entities = this._mongoCollection.AsQueryable().Where(expression);

            return entities;
        }

        private IQueryable<T> GetQueryableByConditionsAndSort<TKey>(Expression<Func<T, bool>> expression, Expression<Func<T, TKey>> sort, Constants.SortTypes sortType)
        {
            IQueryable<T> entities = this.GetQueryableByConditions(expression);

            switch (sortType)
            {
                case Constants.SortTypes.Asc:
                    entities = this._mongoCollection.AsQueryable().Where(expression).OrderBy(sort);
                    break;

                case Constants.SortTypes.Desc:
                    entities = this._mongoCollection.AsQueryable().Where(expression).OrderByDescending(sort);
                    break;
                default:
                    throw new ArgumentException();
            }

            return entities;
        }

        public MongoDBRepository()
        {
            this.RegisterAutoMap();

            IMongoDatabase Database = MongodbContext.GetDatabase();
            String collectionName = this.GetCollectionName();

            this._mongoCollection = Database.GetCollection<T>(collectionName);
        }

        public void DeleteByConditions(Expression<Func<T, bool>> expression)
        {
            this._mongoCollection.DeleteMany(expression);
        }

        public IList<T> GetAll()
        {
            IList<T> entities = this._mongoCollection.AsQueryable().ToList();

            return entities;
        }

        public IList<T> GetAllByConditions(Expression<Func<T, bool>> expression)
        {
            IList<T> entities = this.GetQueryableByConditions(expression).ToList();

            return entities;
        }

        public void Save(T entity)
        {
            this._mongoCollection.InsertOne(entity);
        }

        public IList<T> GetAllByConditionsAndSort<TKey>(Expression<Func<T, bool>> expression, Expression<Func<T, TKey>> sort, Constants.SortTypes sortType)
        {
            IList<T> entities = this.GetQueryableByConditionsAndSort<TKey>(expression, sort, sortType).ToList();

            return entities;
        }

        public T GetFirstByConditions(Expression<Func<T, bool>> expression)
        {
            T entity = this.GetQueryableByConditions(expression).FirstOrDefault();

            return entity;
        }

        public T GetFirstByConditionsAndSort<TKey>(Expression<Func<T, bool>> expression, Expression<Func<T, TKey>> sort, Constants.SortTypes sortType)
        {
            T entity = this.GetQueryableByConditionsAndSort<TKey>(expression, sort, sortType).FirstOrDefault();

            return entity;
        }
    }
}
