namespace RainfallApi.Services
{
    public class RainfallService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RainfallService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


    }
}
