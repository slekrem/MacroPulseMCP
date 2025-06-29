using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public class WorldBankTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Get World Bank categories.")]
    public async Task<string> Get_worldbank_categories()
    {
        return await service.GetData("worldBank/categories");
    }

    [McpServerTool, Description("Get World Bank data by category.")]
    public async Task<string> Get_worldbank_by_category(
        [Description("Category name (e.g. 'Education')")] string category)
    {
        return await service.GetData($"worldBank/category/{category}");
    }

    [McpServerTool, Description("Get World Bank data by category with pagination.")]
    public async Task<string> Get_worldbank_by_category_with_pagination(
        [Description("Category name (e.g. 'Education')")] string category,
        [Description("Page number for pagination")] int page)
    {
        return await service.GetData($"worldBank/category/{category}/{page}");
    }

    [McpServerTool, Description("Get World Bank data by series codes.")]
    public async Task<string> Get_worldbank_by_series(
        [Description("Comma-separated list of series codes (e.g. 'fr.inr.rinr,usa.fr.inr.rinr')")] string seriesCodes)
    {
        return await service.GetData("worldBank/indicator", $"s={seriesCodes}");
    }

    [McpServerTool, Description("Get World Bank data by URL path.")]
    public async Task<string> Get_worldbank_by_url(
        [Description("World Bank URL path (e.g. '/united-states/real-interest-rate-percent-wb-data.html')")] string url)
    {
        return await service.GetData("worldBank/indicator", $"url={url}");
    }

    [McpServerTool, Description("Get World Bank data by country with pagination.")]
    public async Task<string> Get_worldbank_by_country(
        [Description("Country name (e.g. 'united states')")] string country,
        [Description("Page number for pagination")] int page)
    {
        return await service.GetData($"worldBank/country/{country}/{page}");
    }

    [McpServerTool, Description("Get historical World Bank data by series codes.")]
    public async Task<string> Get_worldbank_historical_by_series(
        [Description("Comma-separated list of series codes (e.g. 'usa.fr.inr.rinr')")] string seriesCodes)
    {
        return await service.GetData("worldBank/historical", $"s={seriesCodes}");
    }
}
