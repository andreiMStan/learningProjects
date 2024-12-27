namespace NET_7___Build_CRUD_with_Web_API__EF_Core__Repository_Pattern
{
	public class WeatherForecast
	{
		public DateOnly Date { get; set; }

		public int TemperatureC { get; set; }

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

		public string? Summary { get; set; }
	}
}