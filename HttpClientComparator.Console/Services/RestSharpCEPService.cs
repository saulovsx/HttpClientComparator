using HttpClientComparator.Console.Interfaces;
using RestSharp;

public class RestSharpCEPService : ICEPService
{
    private readonly RestClient _client;

    public RestSharpCEPService()
    {
        _client = new RestClient();
    }

    public async Task<string?> GetCEPInfoAsync(string cep)
    {
        var request = new RestRequest($"https://viacep.com.br/ws/{cep}/json/", Method.Get);
        var response = await _client.ExecuteAsync(request);

        return response.Content;
    }
}