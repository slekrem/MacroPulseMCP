using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public class MarketsTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Get commodities market data.")]
    public async Task<string> Get_commodities()
    {
        return await service.GetData("markets/commodities");
    }

    [McpServerTool, Description("Get currency market data.")]
    public async Task<string> Get_currency()
    {
        return await service.GetData("markets/currency");
    }

    [McpServerTool, Description("Get currency crosses (EUR-based pairs).")]
    public async Task<string> Get_currency_crosses()
    {
        return await service.GetData("markets/currency", "cross=eur");
    }

    [McpServerTool, Description("Get stock market indices data.")]
    public async Task<string> Get_market_indices()
    {
        return await service.GetData("markets/index");
    }

    [McpServerTool, Description("Get bond market data.")]
    public async Task<string> Get_bonds()
    {
        return await service.GetData("markets/bond");
    }

    [McpServerTool, Description("Get market data for specific symbols.")]
    public async Task<string> Get_market_by_symbols(
        [Description("Comma-separated list of symbols (e.g. 'aapl:us,gac:com')")] string symbols)
    {
        return await service.GetData($"markets/symbol/{symbols}");
    }

    [McpServerTool, Description("Get market data for a single symbol.")]
    public async Task<string> Get_market_by_symbol(
        [Description("Market symbol (e.g. 'aapl:us')")] string symbol)
    {
        return await service.GetData($"markets/symbol/{symbol}");
    }

    [McpServerTool, Description("Get peer companies for a given symbol.")]
    public async Task<string> Get_market_peers(
        [Description("Market symbol (e.g. 'aapl:us')")] string symbol)
    {
        return await service.GetData($"markets/peers/{symbol}");
    }

    [McpServerTool, Description("Get components of a stock market index.")]
    public async Task<string> Get_market_components(
        [Description("Index symbol (e.g. 'psi20:ind')")] string symbol)
    {
        return await service.GetData($"markets/components/{symbol}");
    }

    [McpServerTool, Description("Get stock markets by country with pagination.")]
    public async Task<string> Get_markets_by_country(
        [Description("Country name (e.g. 'united states')")] string country,
        [Description("Page number (optional, default is 1)")] int page = 1)
    {
        return await service.GetData($"markets/country/{country}", $"page={page}");
    }
}
