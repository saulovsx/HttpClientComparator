using HttpClientComparator.Console.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using HttpClientComparator.Console.Enums;

namespace HttpClientComparator.Console.Services
{
    public class CEPServiceFactory : ICEPServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CEPServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICEPService CreateCEPService(TypeServiceEnum type)
        {
            return type switch
            {
                TypeServiceEnum.HttpClient => _serviceProvider.GetRequiredService<HttpClientCEPService>(),
                TypeServiceEnum.RestSharp => _serviceProvider.GetRequiredService<RestSharpCEPService>(),
                TypeServiceEnum.Flurl => _serviceProvider.GetRequiredService<FlurlCEPService>(),
                _ => throw new ArgumentException("Invalid CEP service type"),
            };
        }        
    }
}
