using Microsoft.AspNetCore.Mvc;

namespace Todo_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private static List<WeatherForecast> ListaWeatherForecasts = new List<WeatherForecast>();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            if (ListaWeatherForecasts == null || !ListaWeatherForecasts.Any())
            {
                ListaWeatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();
            }
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return ListaWeatherForecasts;
        }

        [HttpPost]
        public IActionResult Post(WeatherForecast model)
        {
            ListaWeatherForecasts.Add(model);

            return Ok(model);
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            ListaWeatherForecasts.RemoveAt(index);

            return Ok();
        }
    }
}
