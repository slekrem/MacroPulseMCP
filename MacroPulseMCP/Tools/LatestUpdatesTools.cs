using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public class LatestUpdatesTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Get the latest updates across all Trading Economics data.")]
    public async Task<string> Get_latest_updates()
    {
        return await service.GetData("updates");
    }

    [McpServerTool, Description("Get latest updates since a specific date.")]
    public async Task<string> Get_latest_updates_since_date(
        [Description("Date in YYYY-MM-DD format to get updates since that date")] string date)
    {
        return await service.GetData($"updates/{date}");
    }
}
