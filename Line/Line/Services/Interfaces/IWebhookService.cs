using Line.Models.Parameters;

namespace Line.Services.Interfaces
{
    public interface IWebhookService
    {
        public void Insert(LineEventPayload payload);
    }
}
