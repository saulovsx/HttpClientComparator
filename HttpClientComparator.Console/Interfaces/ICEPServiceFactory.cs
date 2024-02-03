using HttpClientComparator.Console.Enums;

namespace HttpClientComparator.Console.Interfaces
{
    public interface ICEPServiceFactory
    {
        ICEPService CreateCEPService(TypeServiceEnum type);
    }
}