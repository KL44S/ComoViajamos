using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Implementations.MongoDB
{
    internal class MongoDBConstants
    {
        private static String DBUser = "metro";
        private static String DBPassword = "c3cfb1086c6f159427f8ad239cbf5ea1091533b422c7dd59a7d429f7d35562b4";
        internal static String DBPath = "mongodb://" + DBUser + ":" + DBPassword + "@ds121332.mlab.com:21332/comoviajamos";
        internal static String DBName = "comoviajamos";
    }
}
