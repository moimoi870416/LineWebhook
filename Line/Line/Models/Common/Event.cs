namespace Line.Models.Base
{
    public class Event
    {
        public string Type { get; set; }
        public Message Message { get; set; }
        public string WebhookEventId { get; set; }
        public DeliveryContext DeliveryContext { get; set; }
        public long Timestamp { get; set; }
        public Source Source { get; set; }
        public string ReplyToken { get; set; }
        public string Mode { get; set; }
    }

}
