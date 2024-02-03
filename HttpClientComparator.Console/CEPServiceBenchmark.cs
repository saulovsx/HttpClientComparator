using BenchmarkDotNet.Attributes;
using HttpClientComparator.Console.Interfaces;
using HttpClientComparator.Console.Services;
using HttpClientComparator.Console.Enums;
using Microsoft.Extensions.DependencyInjection;

public class CEPServiceBenchmark
{    
    private readonly ICEPServiceFactory cepServiceFactory;

    public CEPServiceBenchmark()
    {        
        var services = new ServiceCollection();
        services.AddHttpClient();
        services.AddTransient<IRestHttpClient, RestHttpClient>();
        services.AddTransient<HttpClientCEPService>();
        services.AddTransient<RestSharpCEPService>();
        services.AddTransient<FlurlCEPService>();
        services.AddTransient<ICEPServiceFactory, CEPServiceFactory>();

        var serviceProvider = services.BuildServiceProvider();
        cepServiceFactory = serviceProvider.GetRequiredService<ICEPServiceFactory>();        
    }

    [Benchmark]
    public async Task TestHttpClientCEPService()
    {
        var httpClientServiceCEP = cepServiceFactory.CreateCEPService(TypeServiceEnum.HttpClient);        
        await httpClientServiceCEP.GetCEPInfoAsync("01153000");
    }

    [Benchmark]
    public async Task TestRestSharpCEPService()
    {
        var restSharpServiceCEP = cepServiceFactory.CreateCEPService(TypeServiceEnum.RestSharp);
        await restSharpServiceCEP.GetCEPInfoAsync("01153000");
    }

    [Benchmark]
    public async Task TestFlurlCEPService()
    {
        var flurlServiceCEP = cepServiceFactory.CreateCEPService(TypeServiceEnum.Flurl);
        await flurlServiceCEP.GetCEPInfoAsync("01153000");
    }
}