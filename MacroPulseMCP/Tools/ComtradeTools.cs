using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public class ComtradeTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Get list of Comtrade trade categories.")]
    public async Task<string> Get_comtrade_categories()
    {
        return await service.GetData("comtrade/categories");
    }

    [McpServerTool, Description("Get list of Comtrade countries.")]
    public async Task<string> Get_comtrade_countries()
    {
        return await service.GetData("comtrade/countries");
    }

    [McpServerTool, Description("Get Comtrade data for a specific country with pagination.")]
    public async Task<string> Get_comtrade_by_country(
        [Description("Country name (e.g. 'portugal')")] string country,
        [Description("Page number for pagination")] int page)
    {
        return await service.GetData($"comtrade/country/{country}/{page}");
    }

    [McpServerTool, Description("Get bilateral trade data between two countries with pagination.")]
    public async Task<string> Get_comtrade_between_countries(
        [Description("First country name (e.g. 'portugal')")] string country1,
        [Description("Second country name (e.g. 'spain')")] string country2,
        [Description("Page number for pagination")] int page)
    {
        return await service.GetData($"comtrade/country/{country1}/{country2}/{page}");
    }

    [McpServerTool, Description("Get historical Comtrade data by symbol.")]
    public async Task<string> Get_comtrade_historical_by_symbol(
        [Description("Comtrade symbol (e.g. 'PRTESP24031')")] string symbol)
    {
        return await service.GetData($"comtrade/historical/{symbol}");
    }
}
