using RainfallApi.Responses;

namespace RainfallApi.Services.Abstract
{
    public interface IRainfallService
    {
        Task<RainfallReadingResponse> GetReadingsFromApi(string stationId, int count);
    }
}
