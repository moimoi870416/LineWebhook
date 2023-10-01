namespace Line.Models.Base
{
    public class Message
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string QuotedMessageId { get; set; }
        public string QuoteToken { get; set; }
        public string Text { get; set; }
    }
}
