using Microsoft.AspNetCore.Mvc;

namespace IotApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ArchNewsController : ControllerBase
{
    private readonly ILogger<ArchNewsController> _logger;

    public ArchNewsController(ILogger<ArchNewsController> logger)
    {
        _logger = logger;
    }
}
