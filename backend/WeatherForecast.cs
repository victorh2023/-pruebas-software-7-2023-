namespace backend;
/// <summary>
    /// hola
    /// </summary>
public class WeatherForecast
{
    /// <summary>
    /// hola
    /// </summary>
    public DateOnly Date { get; set; }
    /// <summary>
    /// hola
    /// </summary>

    public int TemperatureC { get; set; }
    /// <summary>
    /// hola
    /// </summary>

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    /// <summary>
    /// hola
    /// </summary>
    public string? Summary { get; set; }
}
