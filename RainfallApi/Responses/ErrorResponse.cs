using RainfallApi.Models;

namespace RainfallApi.Responses
{
    public class ErrorResponse
    {
        public required string Message { get; set; }
        public required IEnumerable<ErrorDetail> Detail { get; set; }
    }
}
