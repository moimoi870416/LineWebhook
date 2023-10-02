using MongoDB.Bson.Serialization.Attributes;

namespace Line.Models.Base
{
    [BsonIgnoreExtraElements]
    public class Source
    {
        public string Type { get; set; }
        public string UserId { get; set; }
        public string? GroupId { get; set; }
        public string? RoomId { get; set; }
    }

}