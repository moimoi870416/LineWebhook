using MongoDB.Bson.Serialization.Attributes;

namespace Line.Models.Base
{
    [BsonIgnoreExtraElements]
    public class DeliveryContext
    {
        public bool? IsRedelivery { get; set; }
    }
}
