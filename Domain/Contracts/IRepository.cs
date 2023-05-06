using Domain.Common.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Domain.Contracts
{
    public interface IRepository<TDocument> where TDocument : class, IEntity
    {
        IMongoCollection<TDocument> Collection { get; }

        Task<ObjectId> InsertOneAsync(TDocument document);

        Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);
        Task<IEnumerable<TDocument>> FindAsync(Expression<Func<TDocument, bool>> filterExpression);

        Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);

        Task ReplaceOneAsync(TDocument document);

    }
}
