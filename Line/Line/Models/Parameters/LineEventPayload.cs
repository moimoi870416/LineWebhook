using Line.Models.Base;
using Line.Models.DB;
using MongoDB.Bson.Serialization.Attributes;
using MongoGogo.Connection;
using Newtonsoft.Json;

namespace Line.Models.Parameters
{
    [MongoCollection(typeof(LineMongoDBContext.Test), "LineEventPayload")]
    [BsonIgnoreExtraElements]
    public class LineEventPayload
    {
        public string? Destination { get; set; }

        [JsonProperty("events")]
        public List<Event>? Events { get; set; }

        public DateTime? ReceiveTime { get; set; }
    }
}
