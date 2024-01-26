using AutoMapper;
using RainfallApi.Exceptions;
using RainfallApi.Models;
using RainfallApi.Responses;
using RainfallApi.Services.Abstract;

namespace RainfallApi.Services
{
    public class RainfallService : IRainfallService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public RainfallService(
            IHttpClientFactory httpClientFactory,
            IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<RainfallReadingResponse> GetReadingsFromApi(string stationId, int count)
        {
            if (count is < 1 or > 100)
                throw new NotAcceptableException("The field count must be between 1 and 100.", nameof(count));

            using var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<ReadingApiModel>($"https://environment.data.gov.uk/flood-monitoring/id/stations/{stationId}/readings?_sorted&_limit={count}");

            if (response is null || !response.Items.Any())
                throw new NotFoundException("No readings found for the specified stationId");

            var result = _mapper.Map<RainfallReadingResponse>(response);

            return result;
        }
    }
}
