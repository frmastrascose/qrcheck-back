using Domain.Common.Collections;
using Domain.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using System.Reflection;

namespace Data.MongoDB.Repositories
{
    public class BaseRepository<TDocument> : IRepository<TDocument>
        where TDocument : class, IEntity
    {
        public BaseRepository(IDatabase dbConnection)
        {
            Collection = dbConnection.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        public IMongoCollection<TDocument> Collection { get; }

        public async Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            await Collection.FindOneAndDeleteAsync(filterExpression); 
        }

        public async Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
           return await Collection.Find(filterExpression).FirstOrDefaultAsync();
        }

        public async Task InsertOneAsync(TDocument document)
        {
            document.CreatedAt = DateTime.UtcNow;
            document.LastModifiedAt = DateTime.UtcNow;

            if (document.Id == default)
            {
                document.Id = ObjectId.GenerateNewId();
            }
                
            await Collection.InsertOneAsync(
                document,
                new InsertOneOptions
                {
                    BypassDocumentValidation = false
                }
            );
        }

        public async Task ReplaceOneAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);

            await Collection.FindOneAndReplaceAsync(filter, document);
        }

        private string GetCollectionName(ICustomAttributeProvider documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), false)
             .FirstOrDefault())?.CollectionName;
        }
    }
}
