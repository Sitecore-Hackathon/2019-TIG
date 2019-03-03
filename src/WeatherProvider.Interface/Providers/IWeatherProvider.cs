using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProvider.Interface.Data;

namespace WeatherProvider.Interface.Providers
{
    /// <summary>
    /// Intarface for future weather providers
    /// </summary>
    public interface IWeatherProvider
    {
        /// <summary>
        /// Main method for gathering weather data
        /// </summary>
        /// <param name="country">Country</param>
        /// <param name="city">City</param>
        /// <returns></returns>
        List<WeatherData> GetWeatherData(string country, string city);
    }
}
