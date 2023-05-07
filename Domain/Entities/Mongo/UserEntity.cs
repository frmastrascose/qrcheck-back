using Domain.Common.Base;
using Domain.Common.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.Mongo
{
    [BsonCollection("users")]
    public class UserEntity : Document
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email{ get; set; }

        [BsonElement("login")]
        public string Login { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("CPF")]
        public string CPF { get; set; }
        
        [BsonElement("Telephone")]
        public string Telephone { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }
    }
}
