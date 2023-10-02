using MongoDB.Bson.Serialization.Attributes;

namespace Line.Models.Base
{
    [BsonIgnoreExtraElements]
    public class Message
    {
        public string? Type { get; set; }
        public string? Id { get; set; }
        public string? Text { get; set; }
        public string? QuoteToken { get; set; }

    }
}
