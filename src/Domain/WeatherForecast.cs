namespace Domain;

public class WeatherForecast
{
    public DateOnly Date { get; }
    public int TemperatureC { get; }
    public string Summary { get; } = string.Empty;
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public WeatherForecast(DateOnly date, int temperatureC)
    {
        Date = date;
        TemperatureC = temperatureC;
    }
}
