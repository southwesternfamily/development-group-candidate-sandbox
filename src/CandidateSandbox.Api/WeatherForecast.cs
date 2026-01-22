namespace CandidateSandbox.Api;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    private int TemperatureF => 32 + (int)(TemperatureC * 9 / 5.0);

    public string? Summary { get; set; }
}
