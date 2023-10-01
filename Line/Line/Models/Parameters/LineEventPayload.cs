using Line.Models.Base;
using Line.Models.DB;
using MongoGogo.Connection;

namespace Line.Models.Parameters
{
    [MongoCollection(typeof(LineMongoDBContext.Test), "LineEventPayload")]
    public class LineEventPayload
    {
        public string Destination { get; set; }
        public List<Event> Events { get; set; }
    }
}
