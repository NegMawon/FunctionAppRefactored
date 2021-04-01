using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAppRefactored.Weather.Service
{
    public class WeatherService : IWeatherService
    {
        public Task<List<Weather>> GetWeatherDataAsync()
        {
            var weatherData = new List<Weather>();
            weatherData.Add(new Weather()
            {
                WindDir = "NE",
                Lon = -78.63861,
                Pres = 1006.6,
                Timezone = "America/New_York",
                CountryCode = "US"
            });

            weatherData.Add(new Weather()
            {
                WindDir = "NE",
                Lon = -121.887,
                Pres = 1012.5,
                Timezone = "America/Los_Angeles",
                CountryCode = "US"
            });

            weatherData.Add(new Weather()
            {
                WindDir = "NE",
                Lon = -87.6321,
                Pres = 1000.8,
                Timezone = "America/Chicago",
                CountryCode = "US"
            });
            return Task.FromResult(weatherData);
        }
    }
}
