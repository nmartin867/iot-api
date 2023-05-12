using Autofac;
using Autofac.Extensions.DependencyInjection;
using IotApi;


var host = Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureWebHostDefaults(webHostBuilder => webHostBuilder.UseStartup<Startup>())
    .Build();

await host.RunAsync();
