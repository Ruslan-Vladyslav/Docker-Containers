using AppWeather.Service;
using Serilog;
using Microsoft.AspNetCore.Mvc;

namespace AppWeather.Controller
{
    [ApiController]
    [Route("/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _service;
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(WeatherService service, ILogger<WeatherController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllWeather());
        }

        // request for cities like: /weather/city
        [HttpGet("{city}")]
        public IActionResult Get(string city)
        {
            var result = _service.GetWeather(city);

            if (result is null)
            {
                _logger.LogWarning("Get request for {city} not found", city);
                return NotFound();
            }

            _logger.LogInformation("Weather data requested for {city}", city);

            return Ok(result);
        }
    }
}
