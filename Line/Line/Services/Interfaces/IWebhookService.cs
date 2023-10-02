using Line.Models.Logs;
using Line.Models.Parameters;
using Line.Models.Response;

namespace Line.Services.Interfaces
{
    public interface IWebhookService
    {
        public LineResponse Insert(LineEventPayload payload);
        public List<LogInfo> GetLog();
        public List<LineResponse> GetPayload(PayloadFilterParameter filterParameter);
    }
}
