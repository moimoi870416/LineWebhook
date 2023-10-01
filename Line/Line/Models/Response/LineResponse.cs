using Line.Models.Base;

namespace Line.Models.Response
{
    public class LineResponse
    {
        public string Destination { get; set; }
        public List<Event> Events { get; set; }
    }
}
