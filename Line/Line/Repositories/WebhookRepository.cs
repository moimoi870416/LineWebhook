using Line.Models.DB.Logs;
using Line.Models.Parameters;
using Line.Models.Response;
using Line.Repositories.Interface;
using LinqKit;
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

        public List<LogInfo> GetLog(DateTime? startTime)
        {
            //處理映射: 資料減量
            Expression<Func<GoProjectionBuilder<LogInfo>, GoProjectionDefinition<LogInfo>>> projectBuilder =
                proj => proj.Exclude(logInfo => logInfo.Response)
                            .Exclude(logInfo => logInfo.Request.Headers);

            if(startTime == default) return logInfoCollection.Find(filter: _ => true,
                                                                   projection: projectBuilder).ToList();
            else
            {
                return logInfoCollection.Find(filter: log => log.ReceiveTime >= startTime,
                                              projection: projectBuilder).ToList();
            }
        }

        public List<LineResponse> GetPayload(PayloadFilterParameter filterParameter)
        {
            var filter = PredicateBuilder.New<LineEventPayload>(false);
            bool conditionAdded = false;

            if (!string.IsNullOrEmpty(filterParameter.Type))
            {
                filter = filter.Or(lineEventPayload => lineEventPayload.Events.Any(@event => @event.Type == filterParameter.Type));
                conditionAdded = true;
            }
            if (!string.IsNullOrEmpty(filterParameter.SourceType))
            {
                filter = filter.Or(lineEventPayload => lineEventPayload.Events.Any(@event => @event.Source.Type == filterParameter.SourceType));
                conditionAdded = true;
            }
            if (!string.IsNullOrEmpty(filterParameter.GroupId))
            {
                filter = filter.Or(lineEventPayload => lineEventPayload.Events.Any(@event => @event.Source.GroupId == filterParameter.GroupId));
                conditionAdded = true;
            }
            if (!string.IsNullOrEmpty(filterParameter.UserId))
            {
                filter = filter.Or(lineEventPayload => lineEventPayload.Events.Any(@event => @event.Source.UserId == filterParameter.UserId));
                conditionAdded = true;
            }

            // 如果都沒有條件，則選擇所有資料。
            if (!conditionAdded)
            {
                filter = PredicateBuilder.New<LineEventPayload>(true);
            }

            var datas = lineEventPayloadCollection.Find(filter: filter,
                                                        goFindOption: new GoFindOption<LineEventPayload>
                                                        {
                                                            Limit = conditionAdded? null: 10,
                                                            Sort = sorter => sorter.OrderByDescending(lineEventPayload => lineEventPayload.ReceiveTime)
                                                        }).ToList();


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
