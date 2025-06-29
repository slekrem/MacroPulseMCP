using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public class FederalReserveTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Get list of Federal Reserve states.")]
    public async Task<string> Get_fred_states()
    {
        return await service.GetData("fred/states");
    }

    [McpServerTool, Description("Get Federal Reserve data for a specific county.")]
    public async Task<string> Get_fred_county(
        [Description("County name (e.g. 'arkansas')")] string county)
    {
        return await service.GetData($"fred/counties/{county}");
    }

    [McpServerTool, Description("Get Federal Reserve data by symbol.")]
    public async Task<string> Get_fred_by_symbol(
        [Description("FRED symbol (e.g. 'ALLMARGATTN')")] string symbol)
    {
        return await service.GetData($"fred/snapshot/symbol/{symbol}");
    }

    [McpServerTool, Description("Get Federal Reserve data by URL.")]
    public async Task<string> Get_fred_by_url(
        [Description("FRED URL path (e.g. '/united-states/income-inequality-in-aleutians-east-borough-ak-fed-data.html')")] string url)
    {
        return await service.GetData("fred/snapshot/url", $"url={url}");
    }

    [McpServerTool, Description("Get Federal Reserve snapshot data by country.")]
    public async Task<string> Get_fred_snapshot_by_country(
        [Description("Country name (e.g. 'united states')")] string country)
    {
        return await service.GetData($"fred/snapshot/country/{country}");
    }

    [McpServerTool, Description("Get Federal Reserve snapshot data by state.")]
    public async Task<string> Get_fred_snapshot_by_state(
        [Description("State name (e.g. 'tennessee')")] string state)
    {
        return await service.GetData($"fred/snapshot/state/{state}");
    }

    [McpServerTool, Description("Get Federal Reserve snapshot data by county.")]
    public async Task<string> Get_fred_snapshot_by_county(
        [Description("County name (e.g. 'arkansas')")] string county)
    {
        return await service.GetData($"fred/snapshot/county/{county}");
    }

    [McpServerTool, Description("Get Federal Reserve snapshot data by country with pagination.")]
    public async Task<string> Get_fred_snapshot_by_country_with_pagination(
        [Description("Country name (e.g. 'united states')")] string country,
        [Description("Page number for pagination")] int page)
    {
        return await service.GetData($"fred/snapshot/country/{country}/{page}");
    }

    [McpServerTool, Description("Get historical Federal Reserve data by symbol.")]
    public async Task<string> Get_fred_historical_by_symbol(
        [Description("FRED symbol (e.g. 'RACEDISPARITY005007')")] string symbol)
    {
        return await service.GetData($"fred/historical/{symbol}");
    }

    [McpServerTool, Description("Get historical Federal Reserve data by multiple symbols.")]
    public async Task<string> Get_fred_historical_by_symbols(
        [Description("Comma-separated list of FRED symbols (e.g. 'RACEDISPARITY005007,2020RATIO002013')")] string symbols)
    {
        return await service.GetData($"fred/historical/{symbols}");
    }
}
