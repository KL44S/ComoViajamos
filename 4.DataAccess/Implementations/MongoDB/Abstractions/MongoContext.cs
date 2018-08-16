using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Implementations.MongoDB.Abstractions
{
    internal class MongodbContext
    {
        private static MongoClient _mongoClient = new MongoClient(MongoDBConstants.DBPath);

        public static IMongoDatabase GetDatabase()
        {
            return GetDatabase(MongoDBConstants.DBName);
        }

        public static IMongoDatabase GetDatabase(String dbName)
        {
            IMongoDatabase database = _mongoClient.GetDatabase(dbName);

            return database;
        }
    }
}
