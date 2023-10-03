using HttpContextCatcher;
using HttpContextCatcher.CatcherManager;
using HttpContextCatcher.Extension.Bsons;
using Line.Controllers;
using Line.Models.DB.Logs;
using MongoGogo.Connection;

namespace Line.Loggers
{
    public class LogCatcher : IAsyncCatcherService
    {
        private readonly IGoCollection<LogInfo> logInfoCollection;

        public LogCatcher(IGoCollection<LogInfo> logInfoCollection)
        {
            this.logInfoCollection = logInfoCollection;
        }

        public async Task OnCatchAsync(ContextCatcher contextCatcher)
        {
            //查log的api不要記錄下來
            if (contextCatcher.Request.Path == "/api/LineBot/Log") return;

            try
            {
                var bson = contextCatcher.ToBsonType();
                LogInfo logInfo = new LogInfo
                {
                    ReceiveTime = DateTime.Now.AddHours(8),
                    Request = bson.Request,
                    Response = bson.Response
                };

                await logInfoCollection.InsertOneAsync(logInfo);
            }
            catch
            {

            }
        }
    }
}
