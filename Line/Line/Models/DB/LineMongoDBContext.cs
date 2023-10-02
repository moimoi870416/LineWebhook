using MongoGogo.Connection;

namespace Line.Models.DB
{
    public class LineMongoDBContext : GoContext<LineMongoDBContext>
    {
        [MongoDatabase]
        public class Test { }

        [MongoDatabase]
        public class Log { }

        public LineMongoDBContext(string connectionString) : base(connectionString)
        {
        }
    }
}
