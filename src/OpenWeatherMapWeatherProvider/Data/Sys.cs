﻿using Newtonsoft.Json;
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
    public class Sys
    {

        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}
