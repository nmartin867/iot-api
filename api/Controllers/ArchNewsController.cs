using IotApi.Model;
using IotApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IotApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ArchNewsController : ControllerBase
{
    private readonly IArchNewsService _archNewsService;

    public ArchNewsController(IArchNewsService archNewsService)
    {
        _archNewsService = archNewsService;
    }
    [HttpGet]
    public async Task<RssFeedResult> Get()
    {
        return await _archNewsService.GetRssFeed();
    }
}
