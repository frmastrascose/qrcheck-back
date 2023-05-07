using Domain.Common.Base;
using Domain.Common.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.Mongo
{
    [BsonCollection("travelers")]
    public class TravelerEntity : Document
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Email")]
        public string Email{ get; set; }
         
        [BsonElement("CPF")]
        public string CPF { get; set; }
        
        [BsonElement("Telephone")]
        public string Telephone { get; set; }

        [BsonElement("Accessibility")]
        public string Accessibility { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }

        [BsonElement("Confirmation")]
        public bool Confirmation { get; set; }

        [BsonElement("FoodRestriction")]
        public bool FoodRestriction { get; set; }

        [BsonElement("Pronoun")]
        public bool Pronoun { get; set; }

    }
}
