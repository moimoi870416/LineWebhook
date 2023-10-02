using Line.Models.Logs;
using Line.Models.Parameters;
using Line.Models.Response;
using Line.Repositories.Interface;
using MongoDB.Driver;
using MongoGogo.Connection;
using System.Linq.Expressions;

namespace Line.Repositories
{
    public class WebhookRepository : IWebhookRepository
    {
        private readonly IGoCollection<LineEventPayload> lineEventPayloadCollection;
        private readonly IGoCollection<LogInfo> logInfoCollection;

        public WebhookRepository(IGoCollection<LineEventPayload> lineEventPayloadCollection,
                                 IGoCollection<LogInfo> logInfoCollection)
        {
            this.lineEventPayloadCollection = lineEventPayloadCollection;
            this.logInfoCollection = logInfoCollection;
        }

        public List<LogInfo> GetLog()
        {
            return logInfoCollection.Find(_ => true).ToList();
        }

        public List<LineResponse> GetPayload(PayloadFilterParameter filterParameter)
        {
            var filter = Builders<LineEventPayload>.Filter.Where(_ => false);

            if (string.IsNullOrEmpty(filterParameter.Type))
            {
                filter |= Builders<LineEventPayload>.Filter.Where(lineEventPayload => lineEventPayload.Events.Any(@event => @event.Type == filterParameter.Type));
            }
            if (string.IsNullOrEmpty(filterParameter.SourceType))
            {
                filter |= Builders<LineEventPayload>.Filter.Where(lineEventPayload => lineEventPayload.Events.Any(@event => @event.Source.Type == filterParameter.SourceType));
            }
            if (string.IsNullOrEmpty(filterParameter.GroupId))
            {
                filter |= Builders<LineEventPayload>.Filter.Where(lineEventPayload => lineEventPayload.Events.Any(@event => @event.Source.GroupId == filterParameter.GroupId));
            }
            if (string.IsNullOrEmpty(filterParameter.UserId))
            {
                filter |= Builders<LineEventPayload>.Filter.Where(lineEventPayload => lineEventPayload.Events.Any(@event => @event.Source.UserId == filterParameter.UserId));
            }

            //all
            if (string.IsNullOrEmpty(filterParameter.Type) &&
                string.IsNullOrEmpty(filterParameter.SourceType) &&
                string.IsNullOrEmpty(filterParameter.GroupId) &&
                string.IsNullOrEmpty(filterParameter.UserId))
            {
                filter = Builders<LineEventPayload>.Filter.Where(_ => true);
            }


            var datas = lineEventPayloadCollection.MongoCollection.Find(filter).ToList();


            return datas.Select(data => new LineResponse
            {
                Destination = data.Destination,
                Events = data.Events
            }).ToList();
        }

        public LineResponse Insert(LineEventPayload payload)
        {
            payload.ReceiveTime ??= DateTime.Now;
            lineEventPayloadCollection.InsertOne(payload);

            return new LineResponse
            {
                Destination = payload.Destination,
                Events = payload.Events,
            };
        }
    }
}
