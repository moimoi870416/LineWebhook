using Line.Models.Parameters;
using Line.Models.Response;

namespace Line.Services.Interfaces
{
    public interface IWebhookService
    {
        public LineResponse Insert(LineEventPayload payload);
    }
}
