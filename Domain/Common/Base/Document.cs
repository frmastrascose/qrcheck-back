﻿using Domain.Contracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Domain.Common.Base
{
    public abstract class Document : IEntity
    {
        [JsonIgnore]
        public ObjectId Id { get; set;}

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("lastModifiedAt")]
        public DateTime LastModifiedAt { get; set; }
    }
}
