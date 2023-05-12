using Autofac;
using IotApi.Services;

namespace IotApi;

public class AutofacModule: Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
        builder.RegisterType<ArchNewsService>().As<IArchNewsService>();
    }
}