using System.Threading.Tasks;
using FunctionAppRefactored.Weather.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

/// <summary>
/// Class to mock the weather data hard coded in the WeatherService
/// </summary>
namespace FunctionAppRefactored
{
    public class GetWeatherDemo        
    {
        private readonly IWeatherService weatherService;

        public GetWeatherDemo(IWeatherService _weatherService)
        {
            weatherService = _weatherService;
        }

        [FunctionName("GetWeatherDemo")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var weatherData = await weatherService.GetWeatherDataAsync();

            return new OkObjectResult(weatherData);

            
        }
    }
}

