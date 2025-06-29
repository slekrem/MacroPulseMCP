
using Microsoft.Extensions.Options;

public class TradingEconomicsService(IOptions<MacroPulseMcpOptions> _opt) : ITradingEconomicsService
{
    public async Task<string> GetData(string path, string query = "")
    {
        var requestUri = $"https://api.tradingeconomics.com/{path}?c={_opt.Value.ApiKey}&f=json";
        if (!string.IsNullOrWhiteSpace(query))
            requestUri += $"&{query}";

        using var httpClient = new HttpClient();
        using var request = new HttpRequestMessage(new HttpMethod("GET"), requestUri);
        request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
        var response = await httpClient.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        
        // Read error details from response
        var errorContent = await response.Content.ReadAsStringAsync();
        var errorMessage = $"HTTP {(int)response.StatusCode} {response.StatusCode}";
        
        if (!string.IsNullOrWhiteSpace(response.ReasonPhrase))
        {
            errorMessage += $" - {response.ReasonPhrase}";
        }
        
        if (!string.IsNullOrWhiteSpace(errorContent))
        {
            errorMessage += $"\nResponse: {errorContent}";
        }
        
        errorMessage += $"\nRequest: {requestUri}";
        
        return $"Error: {errorMessage}";
    }
}
