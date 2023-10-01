using MongoGogo.Connection;

namespace Line.Models
{
    public class LineMongoDBContext : GoContext<LineMongoDBContext>
    {
        [MongoDatabase]
        public class Test { }

        public LineMongoDBContext(string connectionString) : base(connectionString)
        {
        }
    }
}
