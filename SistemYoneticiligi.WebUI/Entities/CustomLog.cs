using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemYoneticiligi.WebUI.Entities
{
    public class CustomLog : IEntity
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }

    }


}