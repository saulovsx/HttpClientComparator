namespace HttpClientComparator.Console.Interfaces
{
    public interface ICEPService
    {
        Task<string?> GetCEPInfoAsync(string cep);
    }
}
