# development-group-candidate-sandbox

A public sandbox repo in which the development group maintains a solution referenced when interviewing/evaluating developer-candidates.

## Overview

This repository contains a .NET 8 Web API solution built using ASP.NET Core. The solution demonstrates a functional RESTful API with controller-based endpoints, Swagger/OpenAPI documentation, and modern .NET development practices.

## Technology Stack

- **.NET 8.0** - The latest LTS version of .NET
- **ASP.NET Core Web API** - Framework for building HTTP services
- **Swagger/OpenAPI** - API documentation and testing interface
- **Visual Studio** - Primary IDE (solution file included)

## Solution Structure

```
CandidateSandbox.sln                    # Visual Studio solution file
└── src/
    └── CandidateSandbox.Api/           # Web API project
        ├── Controllers/                 # API controllers
        │   └── WeatherForecastController.cs
        ├── Program.cs                   # Application entry point
        ├── WeatherForecast.cs          # Model class
        └── appsettings.json            # Configuration files
```

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (optional, recommended for Windows)
- [Visual Studio Code](https://code.visualstudio.com/) (optional, cross-platform alternative)

## Getting Started

### Building the Solution

#### Using .NET CLI

```bash
# Restore dependencies and build
dotnet build CandidateSandbox.sln
```

#### Using Visual Studio

1. Open `CandidateSandbox.sln` in Visual Studio
2. Press `Ctrl+Shift+B` or select `Build > Build Solution`

### Running the Application

#### Using .NET CLI

```bash
# Run the API (from the repository root)
cd src/CandidateSandbox.Api
dotnet run
```

The API will start and listen on:
- HTTP: `http://localhost:5037`
- HTTPS: `https://localhost:7071` (with development certificate)

*Note: You can override these ports using the `--urls` parameter with dotnet run.*

#### Using Visual Studio

1. Open `CandidateSandbox.sln` in Visual Studio
2. Press `F5` to run with debugging, or `Ctrl+F5` to run without debugging
3. The API will launch and a browser window will open to the Swagger UI

## API Endpoints

The API includes a `WeatherForecastController` with the following endpoints:

### GET /api/WeatherForecast

Returns a 5-day weather forecast.

**Example:**
```bash
curl http://localhost:5037/api/WeatherForecast
```

**Response:**
```json
[
  {
    "date": "2026-01-23",
    "temperatureC": 32,
    "temperatureF": 89,
    "summary": "Hot"
  },
  ...
]
```

### GET /api/WeatherForecast/{days}

Returns the weather forecast for a specific day (1-30 days from now).

**Example:**
```bash
curl http://localhost:5037/api/WeatherForecast/3
```

**Response:**
```json
{
  "date": "2026-01-25",
  "temperatureC": 29,
  "temperatureF": 84,
  "summary": "Bracing"
}
```

### POST /api/WeatherForecast

Creates a new weather forecast entry.

**Example:**
```bash
curl -X POST http://localhost:5037/api/WeatherForecast \
  -H "Content-Type: application/json" \
  -d '{"date":"2026-02-01","temperatureC":20,"summary":"Mild"}'
```

**Response:**
```json
{
  "date": "2026-02-01",
  "temperatureC": 20,
  "temperatureF": 67,
  "summary": "Mild"
}
```

## Swagger UI

When running in Development mode, the API includes Swagger UI for interactive API documentation and testing.

Access Swagger UI at: `http://localhost:5037/swagger`

The Swagger interface allows you to:
- View all available endpoints
- See request/response schemas
- Test API calls directly from the browser

## Development

### Project Features

- **Controller-based routing** - Uses ASP.NET Core MVC controllers
- **Dependency Injection** - Built-in DI container for services
- **Logging** - Integrated logging using `ILogger`
- **API Documentation** - Automatic OpenAPI/Swagger documentation
- **Environment-specific configuration** - Separate settings for Development and Production

### Adding New Controllers

To add a new controller:

1. Create a new class in the `Controllers` folder
2. Inherit from `ControllerBase`
3. Add the `[ApiController]` and `[Route]` attributes
4. Implement your action methods with appropriate HTTP method attributes

Example:
```csharp
[ApiController]
[Route("api/[controller]")]
public class MyController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }
}
```

## Configuration

Application settings can be configured in:
- `appsettings.json` - Default settings for all environments
- `appsettings.Development.json` - Development-specific settings

## Testing

You can test the API using:
- **Swagger UI** - Interactive browser-based testing
- **curl** - Command-line HTTP requests (see examples above)
- **Postman** - Popular API testing tool
- **HTTP files** - Use the included `CandidateSandbox.Api.http` file with compatible tools

## Troubleshooting

### Port Already in Use

If port 5037 or 7071 is already in use, you can specify different ports:

```bash
dotnet run --urls="http://localhost:5100"
```

### HTTPS Certificate Issues

If you encounter HTTPS certificate errors on first run:

```bash
dotnet dev-certs https --trust
```

## Additional Resources

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [.NET API Documentation](https://docs.microsoft.com/dotnet/api)
- [REST API Best Practices](https://docs.microsoft.com/azure/architecture/best-practices/api-design)
