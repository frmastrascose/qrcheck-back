using Domain.Common.Constants;
using Microsoft.Extensions.Configuration;

namespace Data.MongoDB.Configuration
{
    public class MongoDbConnection : Connection
    {
        public MongoDbConnection(IConfiguration configuration)
        {
            ConnectionString = configuration[MongoDbConstants.MONGODB_CONNECTION_STRING];
            Path = configuration[MongoDbConstants.MONGODB_DATABASE];

        }
        public override string ConnectionString { get; }
        public override string Path { get; }
    }
}
