using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public class IndicatorsTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Get all economic indicators without filters.")]
    public async Task<string> Get_all_indicators()
    {
        return await service.GetData("indicators");
    }

    [McpServerTool, Description("Get economic indicators for a specific country.")]
    public async Task<string> Get_indicators_by_country([Description("Name of the country (e.g. 'mexico', 'united states')")] string country)
    {
        return await service.GetData($"country/{country}");
    }

    [McpServerTool, Description("Get a specific indicator for all countries.")]
    public async Task<string> Get_indicator_all_countries([Description("Name of the indicator (e.g. 'gdp', 'inflation', 'unemployment')")] string indicator)
    {
        return await service.GetData($"country/all/{indicator}");
    }

    [McpServerTool, Description("Get historical indicators for specific countries and indicators.")]
    public async Task<string> Get_historical_indicators(
        [Description("Comma-separated list of countries (e.g. 'mexico,brazil')")] string countries,
        [Description("Comma-separated list of indicators (e.g. 'gdp,inflation')")] string indicators,
        [Description("Start date in YYYY-MM-DD format (optional)")] string? startDate = null,
        [Description("End date in YYYY-MM-DD format (optional)")] string? endDate = null)
    {
        var path = $"historical/country/{countries}/indicator/{indicators}";
        if (!string.IsNullOrWhiteSpace(startDate) && !string.IsNullOrWhiteSpace(endDate))
        {
            path += $"/{startDate}/{endDate}";
        }
        return await service.GetData(path);
    }

    [McpServerTool, Description("Get historical indicator data using a ticker symbol.")]
    public async Task<string> Get_historical_by_ticker(
        [Description("Ticker symbol (e.g. 'USURTOT' for US unemployment)")] string ticker,
        [Description("Start date in YYYY-MM-DD format (optional)")] string? startDate = null)
    {
        var path = $"historical/ticker/{ticker}";
        if (!string.IsNullOrWhiteSpace(startDate))
        {
            path += $"/{startDate}";
        }
        return await service.GetData(path);
    }
}
