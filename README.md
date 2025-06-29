# MacroPulseMCP

A comprehensive Model Context Protocol (MCP) server that provides access to Trading Economics data through standardized tools. This server exposes economic indicators, market data, forecasts, news, and more through MCP-compatible interfaces.

## Features

MacroPulseMCP provides 13 comprehensive tool categories covering all major Trading Economics API endpoints:

### High Priority Tools
- **IndicatorsTools** - Economic indicators (GDP, inflation, unemployment, etc.)
- **CalendarTools** - Economic calendar events and releases
- **MarketsTools** - Real-time market data (stocks, commodities, currencies, bonds)
- **ForecastsTools** - Economic forecasts and projections
- **NewsTools** - Economic and financial news

### Medium Priority Tools
- **MarketsHistoricalTools** - Historical market price data
- **EarningsTools** - Corporate earnings calendar and data
- **FederalReserveTools** - US Federal Reserve economic data (FRED)
- **LatestUpdatesTools** - Recently updated data tracking

### Specialized Tools
- **RatingsTools** - Credit ratings (sovereign and corporate)
- **ComtradeTools** - International trade statistics
- **WorldBankTools** - World Bank development indicators
- **MarketsIntradayTools** - Real-time intraday trading data

## Installation

### Prerequisites
- .NET 9.0 or later
- Trading Economics API key

### Setup

1. Clone the repository:
```bash
git clone https://github.com/slekrem/MacroPulseMCP.git
cd MacroPulseMCP
```

2. Build the project:
```bash
dotnet build
```

3. Configure your API key in `appsettings.json`:
```json
{
    "TradingEconomics": {
        "ApiKey": "guest:guest"
    }
}
```

## Usage

### Running the MCP Server

```bash
dotnet run --project MacroPulseMCP
```

The server runs via stdio transport and automatically exposes all available tools.

### Available Tools

Each tool category provides multiple methods for accessing specific data:

#### Economic Indicators
- `Get_all_indicators()` - All economic indicators
- `Get_indicators_by_country(country)` - Indicators for specific country
- `Get_indicator_all_countries(indicator)` - Specific indicator for all countries
- `Get_historical_indicators(countries, indicators, startDate?, endDate?)` - Historical data

#### Economic Calendar
- `Get_all_calendar_events()` - All calendar events
- `Get_calendar_events_by_date(startDate, endDate)` - Events by date range
- `Get_calendar_events_by_countries(countries)` - Events by country
- `Get_calendar_events_by_indicator(indicators)` - Events by indicator

#### Markets
- `Get_commodities()` - Commodities prices
- `Get_currency()` - Currency exchange rates
- `Get_market_indices()` - Stock market indices
- `Get_bonds()` - Bond market data
- `Get_market_by_symbols(symbols)` - Data for specific symbols

#### Forecasts
- `Get_forecast_by_country(country)` - Forecasts by country
- `Get_forecasts_by_indicators(indicators)` - Forecasts by indicator
- `Get_forecasts_by_countries_and_indicators(countries, indicators)` - Combined forecasts

#### News
- `Get_latest_news()` - Latest economic news
- `Get_news_by_country(countries)` - News by country
- `Get_news_by_indicator(indicators)` - News by indicator

### API Key

You can use the default test key `guest:guest` for testing, but it has limitations. For production use, obtain your own API key from [Trading Economics](https://tradingeconomics.com/).

## Architecture

The server is built using:
- **.NET 9.0** - Runtime platform
- **ModelContextProtocol** - MCP server framework
- **Microsoft.Extensions.Hosting** - Application hosting
- **Dependency Injection** - Service management

### Key Components

- `ITradingEconomicsService` - HTTP client abstraction for API calls
- `TradingEconomicsService` - Implementation with authentication
- `MacroPulseMcpOptions` - Configuration model for API key
- Tool classes with `[McpServerTool]` attributes for MCP exposure

## Configuration

The server uses standard .NET configuration with support for:
- `appsettings.json` - Base configuration
- `appsettings.{Environment}.json` - Environment-specific settings
- Environment variables

### Configuration Schema

```json
{
    "TradingEconomics": {
        "ApiKey": "string" // Your Trading Economics API key
    }
}
```

## Development

### Adding New Tools

1. Create a new class in the `Tools/` directory
2. Add `[McpServerToolType]` attribute to the class
3. Add `[McpServerTool]` and `[Description]` attributes to methods
4. Use dependency injection to access `ITradingEconomicsService`

Example:
```csharp
[McpServerToolType]
public class CustomTools(ITradingEconomicsService service)
{
    [McpServerTool, Description("Get custom data.")]
    public async Task<string> Get_custom_data(
        [Description("Parameter description")] string parameter)
    {
        return await service.GetData($"custom/{parameter}");
    }
}
```

### Building and Testing

```bash
# Build the project
dotnet build

# Run the server
dotnet run --project MacroPulseMCP

# Clean build artifacts
dotnet clean
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Related Links

- [Trading Economics API Documentation](https://docs.tradingeconomics.com/)
- [Model Context Protocol](https://modelcontextprotocol.io/)
- [Trading Economics Official Examples](https://github.com/tradingeconomics/tradingeconomics)
