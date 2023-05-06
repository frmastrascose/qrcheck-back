using Domain.Common.Constants;
using Microsoft.Extensions.Configuration;

namespace Data.MongoDB.Configuration
{
    public class MongoDbConnection : Connection
    {
        public MongoDbConnection(IConfiguration configuration)
        {
            ConnectionString = configuration[MongoDbConstants.MONGODB_CONNECTION_STRING];
            Protocol = configuration[MongoDbConstants.MONGODB_PROTOCOL];
            Host = configuration[MongoDbConstants.MONGODB_HOST];
            Path = configuration[MongoDbConstants.MONGODB_DATABASE];

            Port =
                string.IsNullOrWhiteSpace(configuration[MongoDbConstants.MONGODB_PORT])
                    ? 27017
                    : int.Parse(configuration[MongoDbConstants.MONGODB_PORT]);

            Username = configuration[MongoDbConstants.MONGODB_USERNAME];
            Password = configuration[MongoDbConstants.MONGODB_PASSWORD];

        }
        public override string ConnectionString { get; }
        public override string Protocol { get; }
        public override string Host { get; }
        public override string Path { get; }
        public override int Port { get; }
        public override string Username { get; }
        public override string Password { get; }
    }
}
