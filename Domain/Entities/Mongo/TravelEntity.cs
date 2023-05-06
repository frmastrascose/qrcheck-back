using Domain.Common.Base;
using Domain.Common.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.Mongo
{
    [BsonCollection("travel")]
    public class TravelEntity : Document
    {
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

        [BsonElement("isActive")]
        public bool IsActive { get; set; }
    }
}
