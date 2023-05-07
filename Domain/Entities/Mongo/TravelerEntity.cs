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
        public string FoodRestriction { get; set; }

        [BsonElement("SocialName")]
        public string SocialName { get; set; }

        [BsonElement("Pronoun")]
        public string Pronoun { get; set; }

        [BsonElement("HotelName")]
        public string HotelName { get; set; }

        [BsonElement("CheckIn")]
        public string CheckIn { get; set; }

        [BsonElement("CheckOut")]
        public string CheckOut { get; set; }

        [BsonElement("ReservationId")]
        public string ReservationId { get; set; }

        [BsonElement("RoomType")]
        public string RoomType { get; set; }

        [BsonElement("RoomNumber")]
        public string RoomNumber { get; set; }

        [BsonElement("CancelData")]
        public string CancelData { get; set; }

        [BsonElement("HotelName")]
        public string HotelName { get; set; }

        [BsonElement("CheckIn")]
        public string CheckIn { get; set; }

        [BsonElement("CheckOut")]
        public string CheckOut { get; set; }

        [BsonElement("ReservID")]
        public string ReservID { get; set; }

        [BsonElement("RoomType")]
        public string RoomType { get; set; }

        [BsonElement("CancelData")]
        public string CancelData { get; set; }

    }
}
