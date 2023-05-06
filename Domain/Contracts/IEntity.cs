using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Contracts
{
    public interface IEntity
    {
        public ObjectId Id { get; set; }

        [BsonElement("createdAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }

        [BsonElement("lastModifiedAt")]
        public DateTime LastModifiedAt { get; set; }
    }
}
