using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherProvider.Interface.Data
{
    /// <summary>
    /// Main weather information object
    /// </summary>
    public class WeatherData
    {
        public DateTime Date { get; set; }

        public double Temp { get; set; }

        public double Pressure { get; set; }

        public WeatherTypes Type { get; set; }
        public string Description { get; set; }

        public double Wind { get; set; }

        public int Clouds { get; set; }
    }

    /// <summary>
    /// Possible weather types
    /// </summary>
    public enum WeatherTypes
    {
        Sunny,
        Cloudy,
        Rainy,
        Windy,
        Snowy
    }
}
