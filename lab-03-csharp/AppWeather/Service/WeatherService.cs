using AppWeather.Model;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace AppWeather.Service
{
    public class WeatherService
    {
        private readonly List<Weather> _weatherList;
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(ILogger<WeatherService> logger)
        {
            _logger = logger;
            var rnd = new Random();

            string[] cities = { "Kyiv", "Lviv", "Odesa", "Dnipro", "Kharkiv" };
            string[] conditions = { "Clear", "Rain", "Cloudy", "Storm", "Snow" };

            _weatherList = cities.Select(city => new Weather
            {
                City = city,
                Temperature = $"{rnd.Next(-5, 35)}°C",
                Condition = conditions[rnd.Next(conditions.Length)]
            }).ToList();

            _logger.LogInformation("Weather is generated for {count} cities", _weatherList.Count);
        }

        public List<Weather> GetAllWeather() => _weatherList;

        public Weather? GetWeather(string city) =>
            _weatherList.FirstOrDefault(w => w.City.Equals(city, StringComparison.OrdinalIgnoreCase));
    }
}
