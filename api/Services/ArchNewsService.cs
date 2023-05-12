using CodeHollow.FeedReader;
using IotApi.Model;
using IotApi.Model.Configuration;
using Microsoft.Extensions.Options;

namespace IotApi.Services;

public interface IArchNewsService
{
    Task<RssFeedResult> GetRssFeed();
}

public class ArchNewsService : IArchNewsService
{
    private readonly ArchNewsConfiguration _rssConfiguration;
    
    public ArchNewsService(IOptions<ArchNewsConfiguration> options)
    {
        _rssConfiguration = options.Value;
    }

    public async Task<RssFeedResult> GetRssFeed()
    {
        var feed = await FeedReader.ReadAsync(_rssConfiguration.HostUrl);
        return new RssFeedResult
        {
            Description = feed.Description,
            Title = feed.Title,
            ImageUrl = feed.ImageUrl,
            LastUpdatedDate = feed.LastUpdatedDate
        };
    }
}