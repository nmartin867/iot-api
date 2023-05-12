using System.Text;
using Autofac;
using IotApi.Model.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
        app.UseAuthorization();
        app.UseAuthentication();
        app.UseEndpoints(builder => builder.MapControllers());
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterModule(new AutofacModule());
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthorization().AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            var jwtConfig = _configuration.GetSection("JWT");
            var signingKey = Encoding.UTF8.GetBytes(
                jwtConfig["Key"] ?? throw new InvalidOperationException()
            );

            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = jwtConfig["Issuer"],
                ValidAudience = jwtConfig["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
            };
        });

        services.Configure<JwtConfiguration>(_configuration.GetSection("JWT"));
        services.Configure<ArchNewsConfiguration>(_configuration.GetSection("ArchNews"));
        services.AddControllers();
    }
}