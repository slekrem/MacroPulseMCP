using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public class NewsTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Get latest economic news without filters.")]
    public async Task<string> Get_latest_news()
    {
        return await service.GetData("news");
    }

    [McpServerTool, Description("Get latest news filtered by country.")]
    public async Task<string> Get_news_by_country(
        [Description("Comma-separated list of countries (e.g. 'mexico,united states')")] string countries)
    {
        return await service.GetData($"news/country/{countries}");
    }

    [McpServerTool, Description("Get latest news filtered by economic indicator.")]
    public async Task<string> Get_news_by_indicator(
        [Description("Comma-separated list of indicators (e.g. 'inflation rate,gdp')")] string indicators)
    {
        return await service.GetData($"news/indicator/{indicators}");
    }

    [McpServerTool, Description("Get news filtered by both country and indicator.")]
    public async Task<string> Get_news_by_country_and_indicator(
        [Description("Comma-separated list of countries (e.g. 'mexico,united states')")] string countries,
        [Description("Comma-separated list of indicators (e.g. 'inflation rate,gdp')")] string indicators)
    {
        return await service.GetData($"news/country/{countries}/{indicators}");
    }

    [McpServerTool, Description("Get paginated news list with custom limit and start index.")]
    public async Task<string> Get_news_with_pagination(
        [Description("Number of news items to return (limit)")] int limit,
        [Description("Starting index for pagination")] int start)
    {
        return await service.GetData("news", $"limit={limit}&start={start}");
    }
}
