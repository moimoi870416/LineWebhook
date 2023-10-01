using Line.Models.Parameters;

namespace Line.Repositories.Interface
{
    public interface IWebhookRepository
    {
        public void Insert(LineEventPayload payload);

    }
}
