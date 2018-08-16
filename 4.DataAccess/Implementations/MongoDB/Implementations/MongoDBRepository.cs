using DataAccess.Abstractions;
using DataAccess.Implementations.MongoDB.Abstractions;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
            IList<T> entities = this._mongoCollection.AsQueryable().Where(expression).ToList();

            return entities;
        }

        public void Save(T entity)
        {
            this._mongoCollection.InsertOne(entity);
        }
    }
}
