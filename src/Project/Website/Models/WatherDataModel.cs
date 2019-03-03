using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherProvider.Interface.Data;

namespace Website.Models
{
    public class WeatherDataModel : WeatherData
    {
        public string ImageUrl { get; set; }

        public WeatherDataModel() { }

        public WeatherDataModel(WeatherData data)
        {
            Date = data.Date;
            Temp = data.Temp;
            Pressure = data.Pressure;
            Type = data.Type;
            Description = data.Description;
            Wind = data.Wind;
            Clouds = data.Clouds;
        }

    }
}