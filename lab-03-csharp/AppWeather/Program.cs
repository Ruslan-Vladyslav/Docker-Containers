
using AppWeather.Service;
using Serilog;

namespace AppWeather
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Serilog: for console info output
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .Enrich.FromLogContext()
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog();

            builder.Services.AddControllers();
            builder.Services.AddSingleton<WeatherService>();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

