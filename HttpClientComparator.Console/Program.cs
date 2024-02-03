using Microsoft.Extensions.DependencyInjection;
using HttpClientComparator.Console.Interfaces;
using HttpClientComparator.Console.Services;
using HttpClientComparator.Console.Enums;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
public static class Program
{
    public static void Main()
    {
        #if DEBUG
         var services = new ServiceCollection();
         ConfigureServices(services);
         var serviceProvider = services.BuildServiceProvider();

         Console.WriteLine("Aplicação iniciada!");

         var cepServiceFactory = serviceProvider.GetRequiredService<ICEPServiceFactory>();
         var httpClientServiceCEP = cepServiceFactory.CreateCEPService(TypeServiceEnum.HttpClient);
         var resultHttpClient = httpClientServiceCEP.GetCEPInfoAsync("01153000").Result;
         Console.WriteLine($"Resultado de busca de CEP com HttpClient: \b\b{resultHttpClient}");

         var restSharpServiceCEP = cepServiceFactory.CreateCEPService(TypeServiceEnum.RestSharp);
         var resultRestSharp = restSharpServiceCEP.GetCEPInfoAsync("01153000").Result;
         Console.WriteLine($"Resultado de busca de CEP com RestSharp: \b\b{resultRestSharp}");

         var flurlServiceCEP = cepServiceFactory.CreateCEPService(TypeServiceEnum.Flurl);
         var resultFlurl = flurlServiceCEP.GetCEPInfoAsync("01153000").Result;
         Console.WriteLine($"Resultado de busca de CEP com Flurl: \b\b{resultFlurl}");

        #else
        var config = ManualConfig.CreateMinimumViable()
             .WithOptions(ConfigOptions.DisableOptimizationsValidator)
             .AddColumnProvider(DefaultColumnProviders.Instance)
             .AddDiagnoser(MemoryDiagnoser.Default)
             .AddJob(Job.Default.WithWarmupCount(1).WithIterationCount(3));

        BenchmarkRunner.Run<CEPServiceBenchmark>(config);
        #endif
    }
    private static void ConfigureServices(IServiceCollection services)
    {        
        services.AddTransient<IRestHttpClient, RestHttpClient>();
        services.AddTransient<HttpClientCEPService>();
        services.AddTransient<RestSharpCEPService>();
        services.AddTransient<FlurlCEPService>();
        services.AddTransient<ICEPServiceFactory, CEPServiceFactory>();
        services.AddHttpClient();
    }
}