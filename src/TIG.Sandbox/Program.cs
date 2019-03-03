using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIG.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckOpenWeatherMapWeatherProvider();
        }


        private static void CheckOpenWeatherMapWeatherProvider()
        {
            OpenWeatherMapWeatherProvider.WeatherProvider openClient = new OpenWeatherMapWeatherProvider.WeatherProvider("372cdc9866f51c1f6531d8ca5fe1022b");

            var ret  = openClient.GetWeatherData("Pl", "Białystok");
        }
    }
}
