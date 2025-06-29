using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public class RatingsTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Get all credit ratings without filters.")]
    public async Task<string> Get_all_ratings()
    {
        return await service.GetData("ratings");
    }

    [McpServerTool, Description("Get credit ratings for a specific country.")]
    public async Task<string> Get_ratings_by_country(
        [Description("Country name (e.g. 'mexico', 'united states')")] string country)
    {
        return await service.GetData($"ratings/{country}");
    }

    [McpServerTool, Description("Get credit ratings for multiple countries.")]
    public async Task<string> Get_ratings_by_countries(
        [Description("Comma-separated list of countries (e.g. 'mexico,sweden')")] string countries)
    {
        return await service.GetData($"ratings/{countries}");
    }

    [McpServerTool, Description("Get historical credit ratings for multiple countries.")]
    public async Task<string> Get_historical_ratings(
        [Description("Comma-separated list of countries (e.g. 'mexico,sweden')")] string countries)
    {
        return await service.GetData($"ratings/historical/{countries}");
    }
}
