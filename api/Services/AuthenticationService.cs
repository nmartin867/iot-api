using IotApi.Model.Configuration;
using Microsoft.Extensions.Options;

namespace IotApi.Services;

public interface IAuthenticationService
{
    
}

public class AuthenticationService: IAuthenticationService
{
    private readonly JwtConfiguration _jwtConfiguration;
    
    public AuthenticationService(IOptions<JwtConfiguration> options)
    {
        _jwtConfiguration = options.Value;
    }
}