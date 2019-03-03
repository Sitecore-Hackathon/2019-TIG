using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using System.Collections.Generic;
using System.Web;
using WeatherProvider.Interface.Data;
using WeatherProvider.Interface.Providers;

namespace Website.Services
{
    public class WeatherService : IWeatherService
    {
        private IWeatherProvider weatherProvider { get; set; }

        public static string WEATHER_INFO_KEY = "WeatherInfo";
        public static string PRODUCT_BOUGHT_KEY = "ProductBoughtKey";
        public static string LOCATION_COUNTRY = "LocationCountry";
        public static string LOCATION_CITY = "LocationCity";

        public WeatherService()
        {
            weatherProvider = new OpenWeatherMapWeatherProvider.WeatherProvider( Sitecore.Configuration.Settings.GetSetting( "OpenwethermapApiKey", "372cdc9866f51c1f6531d8ca5fe1022b") );
        }

        public List<WeatherData> ChceckAdress(string country, string city)
        {
            var data = weatherProvider.GetWeatherData(country, city);
            SetLocationToSession(country, city);
            return data;
        }


        public List<WeatherData> GetWeathersFromSession()
        {
            return HttpContext.Current.Session[WEATHER_INFO_KEY] as List<WeatherData>;
        }

        public void SetWeathersFromSession(List<WeatherData> weathersList)
        {
            HttpContext.Current.Session.Add(WEATHER_INFO_KEY, weathersList);
        }

        public List<string> GetProductsFromSession()
        {
            return HttpContext.Current.Session[PRODUCT_BOUGHT_KEY] as List<string>; 
        }

        public void SetProductsFromSession(List<string> productsList)
        {
            HttpContext.Current.Session.Add(PRODUCT_BOUGHT_KEY, productsList);
        }

        public void SetLocationToSession(string country, string city)
        {
            HttpContext.Current.Session.Add(LOCATION_COUNTRY, country);
            HttpContext.Current.Session.Add(LOCATION_CITY, city);
        }

        public string GetLocationCountry()
        {
            return HttpContext.Current.Session[LOCATION_COUNTRY] as string;
        }

        public string GetLocationCity()
        {
            return HttpContext.Current.Session[LOCATION_CITY] as string;
        }

    }
}