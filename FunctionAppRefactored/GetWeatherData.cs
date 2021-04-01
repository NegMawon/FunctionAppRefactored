using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionAppRefactored
{
    public class GetWeatherData
    {
        private readonly HttpClient _httpClient;
        public GetWeatherData(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }


        [FunctionName("GetWeatherData")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a Get request.");

            string postal_code = req.Query["postal_code"];
            string key = req.Query[Environment.GetEnvironmentVariable("API_KEY")];
            
            if (!string.IsNullOrEmpty(key))
            {
                var responseMessage = await _httpClient.GetAsync("https://api.weatherbit.io/v2.0/current" + postal_code + key);
                var locationWeatherData = responseMessage.Content.ReadAsStringAsync().Result;
                return new OkObjectResult(locationWeatherData);
            }
            else
            {
                throw new ArgumentNullException("Unable to retrieve weather data, key cannot be empty");
            }
            //var responseMessage = await _httpClient.GetAsync("https://api.weatherbit.io/v2.0/current" + postal_code + key);
            //var locationWeatherData = responseMessage.Content.ReadAsStringAsync().Result;

            
        }
    }
}

