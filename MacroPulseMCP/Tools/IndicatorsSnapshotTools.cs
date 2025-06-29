
using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public class IndicatorsSnapshotTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Access trade economics data by country.")]
    public async Task<string> Data_by_country([Description("name of the country")] string country)
    {
        var data = await service.GetData($"country/{country}");
        return data;
    }
}
