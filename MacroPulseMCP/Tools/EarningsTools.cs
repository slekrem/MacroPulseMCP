using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public class EarningsTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Get default earnings calendar.")]
    public async Task<string> Get_earnings_calendar()
    {
        return await service.GetData("earnings");
    }

    [McpServerTool, Description("Get earnings calendar filtered by date.")]
    public async Task<string> Get_earnings_by_date(
        [Description("Date in YYYY-MM-DD format")] string date)
    {
        return await service.GetData("earnings", $"d1={date}");
    }

    [McpServerTool, Description("Get earnings calendar for a specific symbol and date.")]
    public async Task<string> Get_earnings_by_symbol_and_date(
        [Description("Market symbol (e.g. 'aapl:us')")] string symbol,
        [Description("Date in YYYY-MM-DD format")] string date)
    {
        return await service.GetData($"earnings/symbol/{symbol}", $"d1={date}");
    }

    [McpServerTool, Description("Get earnings calendar for a symbol within a date range.")]
    public async Task<string> Get_earnings_by_symbol_and_date_range(
        [Description("Market symbol (e.g. 'aapl:us')")] string symbol,
        [Description("Start date in YYYY-MM-DD format")] string startDate,
        [Description("End date in YYYY-MM-DD format")] string endDate)
    {
        return await service.GetData($"earnings/symbol/{symbol}", $"d1={startDate}&d2={endDate}");
    }

    [McpServerTool, Description("Get earnings calendar filtered by country.")]
    public async Task<string> Get_earnings_by_country(
        [Description("Country name (e.g. 'united states')")] string country)
    {
        return await service.GetData($"earnings/country/{country}");
    }

    [McpServerTool, Description("Get earnings calendar filtered by type (earnings, ipo, dividends).")]
    public async Task<string> Get_earnings_by_type(
        [Description("Type of earnings data: 'earnings', 'ipo', or 'dividends'")] string type)
    {
        return await service.GetData("earnings", $"type={type}");
    }
}
