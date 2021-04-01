using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAppRefactored.Weather.Service
{
    public interface IWeatherService
    {
        Task<List<Weather>> GetWeatherDataAsync();
    }
}
