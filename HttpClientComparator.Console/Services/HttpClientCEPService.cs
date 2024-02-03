using HttpClientComparator.Console.Interfaces;

namespace HttpClientComparator.Console.Services
{
    public class HttpClientCEPService : ICEPService
    {
        private readonly IRestHttpClient _restHttpClient;
        public HttpClientCEPService(IRestHttpClient restHttpClient)
        {
            _restHttpClient = restHttpClient;
        }
        public async Task<string?> GetCEPInfoAsync(string cep)
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";
            var result = await _restHttpClient.GetAsync(url);

            return await result.Content.ReadAsStringAsync();
        }
    }
}