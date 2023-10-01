using Line.Models.Parameters;
using Line.Repositories.Interface;
using MongoGogo.Connection;

namespace Line.Repositories
{
    public class WebhookRepository : IWebhookRepository
    {
        private readonly IGoCollection<LineEventPayload> lineEventPayloadCollection;

        public WebhookRepository(IGoCollection<LineEventPayload> lineEventPayloadCollection)
        {
            this.lineEventPayloadCollection = lineEventPayloadCollection;
        }

        public void Insert(LineEventPayload payload)
        {
            lineEventPayloadCollection.InsertOne(payload);
        }
    }
}
