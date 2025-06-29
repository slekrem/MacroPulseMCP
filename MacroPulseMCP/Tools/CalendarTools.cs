using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public class CalendarTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Get all calendar events without filters.")]
    public async Task<string> Get_all_calendar_events()
    {
        return await service.GetData("calendar");
    }

    [McpServerTool, Description("Get calendar events between two dates.")]
    public async Task<string> Get_calendar_events_by_date(
        [Description("Start date in YYYY-MM-DD format")] string startDate,
        [Description("End date in YYYY-MM-DD format")] string endDate)
    {
        return await service.GetData($"calendar/country/all/{startDate}/{endDate}");
    }

    [McpServerTool, Description("Get calendar events for specific countries.")]
    public async Task<string> Get_calendar_events_by_countries(
        [Description("Comma-separated list of countries (e.g. 'united states,china')")] string countries)
    {
        return await service.GetData($"calendar/country/{countries}");
    }

    [McpServerTool, Description("Get calendar events for specific countries between dates.")]
    public async Task<string> Get_calendar_events_by_countries_and_dates(
        [Description("Comma-separated list of countries (e.g. 'united states,china')")] string countries,
        [Description("Start date in YYYY-MM-DD format")] string startDate,
        [Description("End date in YYYY-MM-DD format")] string endDate)
    {
        return await service.GetData($"calendar/country/{countries}/{startDate}/{endDate}");
    }

    [McpServerTool, Description("Get calendar events for specific economic indicators.")]
    public async Task<string> Get_calendar_events_by_indicator(
        [Description("Comma-separated list of indicators (e.g. 'inflation rate,gdp')")] string indicators)
    {
        return await service.GetData($"calendar/indicator/{indicators}");
    }

    [McpServerTool, Description("Get calendar events for specific indicators between dates.")]
    public async Task<string> Get_calendar_events_by_indicator_and_dates(
        [Description("Comma-separated list of indicators (e.g. 'inflation rate,gdp')")] string indicators,
        [Description("Start date in YYYY-MM-DD format")] string startDate,
        [Description("End date in YYYY-MM-DD format")] string endDate)
    {
        return await service.GetData($"calendar/indicator/{indicators}/{startDate}/{endDate}");
    }

    [McpServerTool, Description("Get calendar events by countries, indicators, and dates.")]
    public async Task<string> Get_calendar_events_by_countries_indicators_dates(
        [Description("Comma-separated list of countries (e.g. 'united states,china')")] string countries,
        [Description("Comma-separated list of indicators (e.g. 'inflation rate,gdp')")] string indicators,
        [Description("Start date in YYYY-MM-DD format")] string startDate,
        [Description("End date in YYYY-MM-DD format")] string endDate)
    {
        return await service.GetData($"calendar/country/{countries}/indicator/{indicators}/{startDate}/{endDate}");
    }

    [McpServerTool, Description("Get calendar events by specific calendar IDs.")]
    public async Task<string> Get_calendar_events_by_id(
        [Description("Comma-separated list of calendar IDs (e.g. '174108,160025')")] string ids)
    {
        return await service.GetData($"calendar/calendarid/{ids}");
    }
}
