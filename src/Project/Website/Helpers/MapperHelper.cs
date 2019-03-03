using System.Collections.Generic;
using WeatherProvider.Interface.Data;
using System.Linq;

namespace Website.Helpers
{
    public static class MapperHelper
    {

        /// <summary>
        /// Map sitecore items Id to Enum WeatherTypes
        /// </summary>
        public static readonly Dictionary<string, WeatherTypes> WeatherTypeSet = new Dictionary<string, WeatherTypes>()
        {

          {
            "{C4916A82-52AB-5B12-9E61-47A03F5359CE}",
            WeatherTypes.Cloudy
          },

          {
            "{E87FFEB7-2870-5BE5-839D-00ABC5C836AA}",
            WeatherTypes.Rainy
          },

          {
            "{B8F89E6C-207F-5E2C-B401-B9C50F41D579}",
            WeatherTypes.Snowy
          },

          {
            "{42910394-3980-5DA9-B825-9FEA26B2C87A}",
            WeatherTypes.Sunny
          },

          {
            "{415AEC76-1F08-5B6C-9D65-6606B8B47C59}",
            WeatherTypes.Windy
          }
        };

        public static readonly Dictionary<WeatherTypes, string> WeaterTypeToItemId = WeatherTypeSet.ToDictionary(kv => kv.Value, kv => kv.Key);

    }
}