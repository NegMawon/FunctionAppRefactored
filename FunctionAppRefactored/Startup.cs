using FunctionAppRefactored.Weather.Service;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// create startup class at the root of the project
/// it is used at the start of the function app
/// register the assembly which specifies the name to use during
/// register ICustomerService dependency
/// Inject the HttpClient dependency
/// </summary>


[assembly: FunctionsStartup(typeof(FunctionAppRefactored.Startup))]

namespace FunctionAppRefactored
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IWeatherService, WeatherService>();
            builder.Services.AddHttpClient();
        }
    }
}
