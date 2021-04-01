using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Creating Interface for the weather service
/// </summary>
namespace FunctionAppRefactored.Weather.Service
{
    public interface IWeatherService
    {
        Task<List<Weather>> GetWeatherDataAsync();
    }
}
