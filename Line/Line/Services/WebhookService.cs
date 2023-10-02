using Line.Models.Logs;
using Line.Models.Parameters;
using Line.Models.Response;
using Line.Repositories.Interface;
using Line.Services.Interfaces;

namespace Line.Services
{
    public class WebhookService : IWebhookService
    {
        private readonly IWebhookRepository _webhookRepository;

        public WebhookService(IWebhookRepository webhookRepository)
        {
            _webhookRepository = webhookRepository;
        }

        public List<LogInfo> GetLog()
        {
            return _webhookRepository.GetLog();
        }

        public List<LineResponse> GetPayload(PayloadFilterParameter filterParameter)
        {
            return _webhookRepository.GetPayload(filterParameter);
        }

        public LineResponse Insert(LineEventPayload payload)
        {
           return _webhookRepository.Insert(payload);
        }
    }
}
