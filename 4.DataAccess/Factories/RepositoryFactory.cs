using DataAccess.Abstractions;
using DataAccess.Implementations.MongoDB.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Factories
{
    public class RepositoryFactory
    {
        private static Techs _currentTech = Techs.MongoDB;

        public enum Techs { MongoDB };

        public static IRepository<T> GetRepository<T>()
        {
            return GetRepository<T>(_currentTech);
        }

        public static IRepository<T> GetRepository<T>(Techs tech)
        {
            IRepository<T> repository;

            switch (tech)
            {
                case Techs.MongoDB:
                    repository = new MongoDBRepository<T>();
                    break;

                default:
                    throw new ArgumentException();
            }

            return repository;
        }
    }
}
