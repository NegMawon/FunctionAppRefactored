using FunctionAppRefactored.Weather.Service;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FunctionAppRefactored.Startup))]

namespace FunctionAppRefactored
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IWeatherService, WeatherService>();
            //builder.Services.AddHttpClient();
        }
    }
}
