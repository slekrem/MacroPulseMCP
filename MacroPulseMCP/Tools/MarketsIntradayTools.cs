using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public class MarketsIntradayTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Get intraday prices for a single market symbol.")]
    public async Task<string> Get_intraday_by_symbol(
        [Description("Market symbol (e.g. 'aapl:us')")] string symbol)
    {
        return await service.GetData($"markets/intraday/{symbol}");
    }

    [McpServerTool, Description("Get intraday prices for a symbol at a specific date and hour.")]
    public async Task<string> Get_intraday_by_symbol_and_datetime(
        [Description("Market symbol (e.g. 'aapl:us')")] string symbol,
        [Description("DateTime in YYYY-MM-DD HH format (e.g. '2017-08-10 15')")] string dateTimeHour)
    {
        return await service.GetData($"markets/intraday/{symbol}", dateTimeHour);
    }

    [McpServerTool, Description("Get intraday data for a symbol within a specific date range.")]
    public async Task<string> Get_intraday_by_symbol_and_date_range(
        [Description("Market symbol (e.g. 'aapl:us')")] string symbol,
        [Description("Start date in YYYY-MM-DD format")] string startDate,
        [Description("End date in YYYY-MM-DD format")] string endDate)
    {
        return await service.GetData($"markets/intraday/{symbol}", $"{startDate}/{endDate}");
    }
}
