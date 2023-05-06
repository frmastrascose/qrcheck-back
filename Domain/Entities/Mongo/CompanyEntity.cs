using Domain.Common.Base;
using Domain.Common.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.Mongo
{
    [BsonCollection("Company")]
    public class CompanyEntity : Document
    {
        [BsonElement("CompanyName")]
        public string CompanyName { get; set; }
      
    }
}