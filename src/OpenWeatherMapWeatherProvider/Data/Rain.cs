using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapWeatherProvider.Data
{
    /// <summary>
    /// openweathermap api object
    /// </summary>
    public class Rain
    {

        [JsonProperty("3h")]
        public double p3h { get; set; }
    }
}
