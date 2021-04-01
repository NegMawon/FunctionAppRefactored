using System;

namespace FunctionAppRefactored.Weather.Service
{
    public class Weather
    {
        public string WindDir { get; set; }
        public double Lon { get; set; }
        public double Pres { get; set; }
        public string Timezone { get; set; }
        public string CountryCode { get; set; }
    }
}
