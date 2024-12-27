using Microsoft.AspNetCore.Mvc;

namespace NET_7___Build_CRUD_with_Web_API__EF_Core_Mohamad.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
	

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public IActionResult Get()
		{
			return Ok();
		}
	}
}