using Line.Models.Parameters;
using Line.Models.Response;
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

        public LineResponse Insert(LineEventPayload payload)
        {
            lineEventPayloadCollection.InsertOne(payload);

            return new LineResponse
            {
                Destination = payload.Destination,
                Events = payload.Events

            };
        }
    }
}
