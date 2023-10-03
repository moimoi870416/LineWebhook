using HttpContextCatcher.Extension.Bsons;
using MongoGogo.Connection;

namespace Line.Models.DB.Logs
{
    [MongoCollection(typeof(LineMongoDBContext.Log))]
    public class LogInfo : GoDocument
    {
        public RequestBson Request { get; set; }

        public ResponseBson Response { get; set; }

        public DateTime? ReceiveTime { get; set; }  
    }
}
