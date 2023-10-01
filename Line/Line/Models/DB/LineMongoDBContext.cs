using MongoGogo.Connection;

namespace Line.Models.DB
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
