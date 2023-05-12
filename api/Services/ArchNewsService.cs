using CodeHollow.FeedReader;
using IotApi.DTOs;
using Microsoft.Extensions.Options;

namespace IotApi.Services;

public interface IArchNewsService
{
    Task<RssFeedResult> GetRssFeed();
}

public class ArchNewsService : IArchNewsService
{
    private readonly ArchNewsSettings _rssSettings;
    
    public ArchNewsService(IOptions<ArchNewsSettings> options)
    {
        _rssSettings = options.Value;
    }

    public async Task<RssFeedResult> GetRssFeed()
    {
        var feed = await FeedReader.ReadAsync(_rssSettings.HostUrl);
        return new RssFeedResult
        {
            Description = feed.Description,
            Title = feed.Title,
            ImageUrl = feed.ImageUrl,
            LastUpdatedDate = feed.LastUpdatedDate
        };
    }
}