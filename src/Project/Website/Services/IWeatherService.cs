using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProvider.Interface.Data;

namespace Website.Services
{
    interface IWeatherService
    {
        List<WeatherData> ChceckAdress(string country, string city);


        List<WeatherData> GetWeathersFromSession();
        void SetWeathersFromSession(List<WeatherData> weathersList);

        List<string> GetProductsFromSession();
        void SetProductsFromSession(List<string> productsList);

        void SetLocationToSession(string country, string city);

        string GetLocationCountry();

        string GetLocationCity();
    }
}
