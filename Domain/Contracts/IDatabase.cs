using MongoDB.Driver;

namespace Domain.Contracts
{
    public interface IDatabase
    {
        public string ConnectionString { get; }
        public IMongoCollection<TDocument> GetCollection<TDocument>(string name);
        public string DatabaseName { get; }
    }
}
