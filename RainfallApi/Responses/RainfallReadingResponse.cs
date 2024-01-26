using RainfallApi.Models;

namespace RainfallApi.Responses
{
    public class RainfallReadingResponse
    {
        public required IEnumerable<RainfallReading> Readings { get; set; }
    }
}
