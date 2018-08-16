using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Implementations.MongoDB
{
    internal class MongoDBConstants
    {
        private static String DBUser = "KL44S";
        private static String DBPassword = "f998dded8d0f8aca812d8e5fdea0143aa190ec4014239bc7e9d3bde3cbd9e140";
        internal static String DBPath = "mongodb://" + DBUser + ":" + DBPassword + "@ds121332.mlab.com:21332/comoviajamos";
        internal static String DBName = "comoviajamos ";
    }
}
