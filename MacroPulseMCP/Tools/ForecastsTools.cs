using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public class ForecastsTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Get economic forecasts for a specific country.")]
    public async Task<string> Get_forecast_by_country(
        [Description("Name of the country (e.g. 'mexico', 'united states')")] string country)
    {
        return await service.GetData($"forecast/country/{country}");
    }

    [McpServerTool, Description("Get economic forecasts for multiple countries.")]
    public async Task<string> Get_forecasts_by_countries(
        [Description("Comma-separated list of countries (e.g. 'mexico,sweden')")] string countries)
    {
        return await service.GetData($"forecast/country/{countries}");
    }

    [McpServerTool, Description("Get forecasts for a specific economic indicator.")]
    public async Task<string> Get_forecast_by_indicator(
        [Description("Name of the indicator (e.g. 'gdp', 'inflation', 'unemployment')")] string indicator)
    {
        return await service.GetData($"forecast/indicator/{indicator}");
    }

    [McpServerTool, Description("Get forecasts for multiple economic indicators.")]
    public async Task<string> Get_forecasts_by_indicators(
        [Description("Comma-separated list of indicators (e.g. 'gdp,population')")] string indicators)
    {
        return await service.GetData($"forecast/indicator/{indicators}");
    }

    [McpServerTool, Description("Get forecasts for a specific country and indicator combination.")]
    public async Task<string> Get_forecast_by_country_and_indicator(
        [Description("Name of the country (e.g. 'mexico')")] string country,
        [Description("Name of the indicator (e.g. 'gdp')")] string indicator)
    {
        return await service.GetData($"forecast/country/{country}/indicator/{indicator}");
    }

    [McpServerTool, Description("Get forecasts for multiple countries and indicators.")]
    public async Task<string> Get_forecasts_by_countries_and_indicators(
        [Description("Comma-separated list of countries (e.g. 'mexico,sweden')")] string countries,
        [Description("Comma-separated list of indicators (e.g. 'gdp,population')")] string indicators)
    {
        return await service.GetData($"forecast/country/{countries}/indicator/{indicators}");
    }
}
