namespace Line.Models.Parameters
{
    public class PayloadFilterParameter
    {
        public string? Destination { get; set; }
        public string? Type { get; set; }
        public string? MessageType { get; set; }

        public string? SourceType { get; set; }
        public string? UserId { get; set; }

        public string? GroupId { get; set; }
    }
}
