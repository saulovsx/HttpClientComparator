using Flurl.Http;
using HttpClientComparator.Console.Interfaces;

public class FlurlCEPService : ICEPService
{
    public async Task<string?> GetCEPInfoAsync(string cep)
    {
        string url = $"https://viacep.com.br/ws/{cep}/json/";
        string response = await url.GetStringAsync();

        return response;
    }
}