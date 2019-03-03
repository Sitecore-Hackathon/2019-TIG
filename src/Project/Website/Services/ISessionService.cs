using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProvider.Interface.Data;

namespace Website.Services
{
    interface ISessionService
    {

        List<WeatherData> GetWeathers();

        void SetWeathers(List<WeatherData> weathersList);

        List<string> GetProducts();

        void SetProducts(List<string> productsList);

        void SetLocation(string country, string city);

        string GetLocationCountry();

        string GetLocationCity();
    }
}
