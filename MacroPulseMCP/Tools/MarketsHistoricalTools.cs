using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public class MarketsHistoricalTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Get historical market data for a single symbol.")]
    public async Task<string> Get_historical_by_symbol(
        [Description("Market symbol (e.g. 'aapl:us', 'gac:com')")] string symbol)
    {
        return await service.GetData($"markets/historical/{symbol}");
    }

    [McpServerTool, Description("Get historical market data for multiple symbols.")]
    public async Task<string> Get_historical_by_symbols(
        [Description("Comma-separated list of symbols (e.g. 'aapl:us,gac:com')")] string symbols)
    {
        return await service.GetData($"markets/historical/{symbols}");
    }

    [McpServerTool, Description("Get historical market data for a symbol within a specific date range.")]
    public async Task<string> Get_historical_by_symbol_and_dates(
        [Description("Market symbol (e.g. 'aapl:us')")] string symbol,
        [Description("Start date in YYYY-MM-DD format")] string startDate,
        [Description("End date in YYYY-MM-DD format")] string endDate)
    {
        return await service.GetData($"markets/historical/{symbol}", $"{startDate}/{endDate}");
    }
}
