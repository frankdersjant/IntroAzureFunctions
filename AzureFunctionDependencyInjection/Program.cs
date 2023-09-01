using AzureFunctionDependencyInjection.DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
      .ConfigureAppConfiguration(configurationBuilder =>
      {
      })
      .ConfigureFunctionsWorkerDefaults()
      .ConfigureServices(services =>
           {
               services.AddTransient<IFakeProductDB, FakeProductsDB>();
           })
            .Build();

host.Run();
