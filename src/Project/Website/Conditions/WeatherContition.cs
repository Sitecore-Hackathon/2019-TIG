using Newtonsoft.Json;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherProvider.Interface.Data;
using Website.Controllers;
using Website.Helpers;
using Website.Services;

namespace Website.Conditions
{
    /// <summary>
    /// Contition for personalized renderings 
    /// custom condition configure in sitecore:
    /// /sitecore/system/Settings/Rules/Definitions/Elements/Tig
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WeatherContition<T> : WhenCondition<T> where T : RuleContext
    {

        // List selected weather from personalization in rendering item
        public string Weather { get; set; }

        protected override bool Execute(T ruleContext)
        {

            if (string.IsNullOrEmpty(this.Weather))
            {
                return false;
            }

            List<WeatherTypes> weathersTypes = this.GetListOfWeathers(this.Weather);

            IWeatherService WeatherService = DependencyResolver.Current.GetService<IWeatherService>();

            // Take info from user session about choosed weather
            var data = WeatherService.GetWeathersFromSession();
            
            List<WeatherData> list = WeatherService.GetWeathersFromSession();

            if (list != null)
            {
                foreach (var weatherSession in list)
                {
                    if (weathersTypes.Contains(weatherSession.Type))
                    {
                        return true;
                    }
                }
            }

            return false;
        }



        private List<WeatherTypes> GetListOfWeathers(string weathersList)
        {

            string[] strArray = weathersList.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            List<WeatherTypes> weatherOfTypeList = new List<WeatherTypes>();

            foreach (string key in strArray)
            {
                if (MapperHelper.WeatherTypeSet.TryGetValue(key, out WeatherTypes weatherType))
                {
                    weatherOfTypeList.Add(weatherType);
                }
                else
                {
                    Log.Error("WeatherContition wrong definition: " + key, (object)this);
                }
            }

            return weatherOfTypeList;
        }
    }
}