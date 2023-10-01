using Line.Models.Parameters;
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

        public void Insert(LineEventPayload payload)
        {
            _webhookRepository.Insert(payload);
        }
    }
}
