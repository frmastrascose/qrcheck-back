using Domain.Contracts;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Data.MongoDB.Configuration
{
    public class MongoDb : IDatabase
    {
        public string ConnectionString { get; }
        public string DatabaseName { get; }

        private readonly IMongoDatabase _database;

        public MongoDb(IConfiguration configuration)
        {
            var connectionConfig = new MongoDbConnection(configuration);

            ConnectionString = connectionConfig.Uri?.ToString();

            var connection = new MongoClient(
                MongoClientSettings.FromConnectionString(ConnectionString)
            );

            _database = connection.GetDatabase(connectionConfig.Path);

            DatabaseName = connectionConfig.Path;
        }


        public IMongoCollection<TDocument> GetCollection<TDocument>(string name)
        {
            return _database.GetCollection<TDocument>(name);
        }
    }
}
