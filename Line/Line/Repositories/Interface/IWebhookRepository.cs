using Line.Models.Parameters;
using Line.Models.Response;

namespace Line.Repositories.Interface
{
    public interface IWebhookRepository
    {
        public LineResponse Insert(LineEventPayload payload);

    }
}
