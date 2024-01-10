using Microsoft.AspNetCore.Mvc;
using WebAPIArchivosConfguracion.Services;

namespace WebAPIArchivosConfguracion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;

        private readonly ClienteCredencialesService _clienteCredencialesService;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration, ClienteCredencialesService clienteCredencialesService)
        {
            _logger = logger;
            _configuration = configuration;
            _clienteCredencialesService = clienteCredencialesService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            string HANAConnectionString = _configuration["Services:AfipService"];

            var credenciales = _clienteCredencialesService.ObtenerCredenciales("Cliente1");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Data = HANAConnectionString
            })
            .ToArray();
        }
    }
}