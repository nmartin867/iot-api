using Autofac;
using IotApi.DTOs;
using IotApi.Services;

namespace IotApi;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(builder => builder.MapControllers());
    }
    
    public void ConfigureContainer(ContainerBuilder builder)
    {
        // Add any Autofac modules or registrations.
        // This is called AFTER ConfigureServices so things you
        // register here OVERRIDE things registered in ConfigureServices.
        //
        // You must have the call to `UseServiceProviderFactory(new AutofacServiceProviderFactory())`
        // when building the host or this won't be called.
        builder.RegisterModule(new AutofacModule());

        // If you want to enable diagnostics, you can do that via a build
        // callback. Diagnostics aren't free, so you shouldn't just do this
        // by default. Note: since you're diagnosing the container you can't
        // ALSO resolve the logger to which the diagnostics get written, so
        // writing directly to the log destination is the way to go.
        /*
        var tracer = new DefaultDiagnosticTracer();
        tracer.OperationCompleted += (sender, args) =>
        {
            Console.WriteLine(args.TraceContent);
        };

        builder.RegisterBuildCallback(c =>
        {
            var container = c as IContainer;
            container.SubscribeToDiagnostics(tracer);
        });
        */
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<ArchNewsSettings>(_configuration.GetSection("ArchNews"));
        services.AddControllers();
    }
}