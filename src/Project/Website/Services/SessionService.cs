using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherProvider.Interface.Data;

namespace Website.Services
{
    public class SessionService : ISessionService
    {
        public static string WEATHER_INFO_KEY = "WeatherInfo";
        public static string PRODUCT_BOUGHT_KEY = "ProductBoughtKey";
        public static string LOCATION_COUNTRY = "LocationCountry";
        public static string LOCATION_CITY = "LocationCity";

        protected void Set<T>(string key, T value)
        {
            HttpContext.Current.Session.Add(key, value);
        }

        //protected T Get<T>(string key) where T: object
        //{
        //    var value = HttpContext.Current.Session[key];
        //    return value is T ? (T)value : null;
        //}

        public List<WeatherData> GetWeathers()
        {
            return HttpContext.Current.Session[WEATHER_INFO_KEY] as List<WeatherData>;
        }

        public void SetWeathers(List<WeatherData> weathersList)
        {
            HttpContext.Current.Session.Add(WEATHER_INFO_KEY, weathersList);
        }

        public List<string> GetProducts()
        {
            return HttpContext.Current.Session[PRODUCT_BOUGHT_KEY] as List<string>;
        }

        public void SetProducts(List<string> productsList)
        {
            HttpContext.Current.Session.Add(PRODUCT_BOUGHT_KEY, productsList);
        }

        public void SetLocation(string country, string city)
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