using System.Web.Mvc;
using Website.Services;
using System;
using System.Linq;
using System.Web.Security;
using Sitecore.Diagnostics;
using Newtonsoft.Json;
using Website.Models;

namespace Website.Controllers
{
    public class WeatherController : Controller
    {
        

        private IWeatherService WeatherService;

        public WeatherController()
        {
            WeatherService = DependencyResolver.Current.GetService<IWeatherService>();
        }

        /// <summary>
        /// Webservice to save user location and download weather to few days
        /// </summary>
        /// <param name="country">PL</param>
        /// <param name="city">Białystok</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult form(string country, string city)
        {
            var weatherDatas = WeatherService.ChceckAdress(country, city);

            if (weatherDatas == null || weatherDatas.Count == 0)
            {
                var error = JsonConvert.SerializeObject(new BaseApiResponse()
                {
                    Message = "not found location",
                    Success = false,
                });
                return this.Content(error, "application/json");
            }

            WeatherService.SetWeathersFromSession(weatherDatas);

            var json = JsonConvert.SerializeObject(new BaseApiResponse() {
                Message = "ok",
                Success = true,
            });
            return Content(json, "application/json");
        }

        [HttpGet]
        public ActionResult GetWeatherUser()
        {
            var weathersList = WeatherService.GetWeathersFromSession();
            return Content(JsonConvert.SerializeObject(weathersList), "application/json");
        }


        /// <summary>
        /// Helper request to check all user session data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string getFullSessionInfo()
        {
            string result = "";
            int i = 0;
            HttpContext.Session.Add("timeNow", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            foreach (var key in HttpContext.Session.Keys)
            {
                result += $"{key} - {HttpContext.Session[i]} || ";
                i++;
            }

            return result;
        }
    }
}