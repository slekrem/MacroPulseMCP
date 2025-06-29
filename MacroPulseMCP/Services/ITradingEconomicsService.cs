public interface ITradingEconomicsService
{
    Task<string> GetData(string path, string query = "");
}
