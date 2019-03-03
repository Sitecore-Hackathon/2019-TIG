using OpenWeatherMapWeatherProvider.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProvider.Interface.Data;
using WeatherProvider.Interface.Providers;

namespace OpenWeatherMapWeatherProvider
{
    /// <summary>
    /// IWeatherProvider implementation, we are using OpenWeatherMap Free API
    /// </summary>
    public class WeatherProvider : IWeatherProvider
    {
        #region PROPERTIES
        /// <summary>
        /// OpenWeatherMap API key
        /// </summary>
        private string ApiKey { get; set; }

        /// <summary>
        /// REST client
        /// </summary>
        private RestClient ApiClient { get; set; }
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="apikey">OpenWeatherMap API key</param>
        public WeatherProvider(string apikey, string baseUrl = "https://api.openweathermap.org")
        {
            ApiKey = apikey;
            ApiClient = new RestClient(baseUrl);
        }

        /// <summary>
        /// Main method for frtch weather data, in this implementation we use openweathermap API (https://openweathermap.org/forecast5#format)
        /// </summary>
        /// <param name="country">Country</param>
        /// <param name="city">City</param>
        /// <returns>List of weather conditions (one object per day), null if something goes wrong</returns>
        public List<WeatherData> GetWeatherData(string country, string city)
        {
            //https://api.openweathermap.org/data/2.5/forecast?q=London,uk&units=metric&appid=372cdc9866f51c1f6531d8ca5fe1022b

            string url = string.Format("/data/2.5/forecast");
            var request = new RestRequest(url, Method.GET);

            request.AddParameter("q", $"{city},{country}");
            request.AddParameter("units", "metric");
            request.AddParameter("appid", ApiKey);

            IRestResponse<WeatherResponse> response = ApiClient.Execute<WeatherResponse>(request);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:

                    return ProcessOpenweathermapApiResponse(response.Data);

                default:
                    break;
            }

            return null;
        }

        /// <summary>
        /// Bissness logic to adjust openweathemap respone data to our needs
        /// </summary>
        /// <param name="apiResponse">Openweathemap Respone object</param>
        /// <returns>List of weather conditions per day</returns>
        private List<WeatherData> ProcessOpenweathermapApiResponse(WeatherResponse apiResponse)
        {
            List<WeatherData> weatherDataList = null;

            if( apiResponse != null )
            {
                weatherDataList = new List<WeatherData>();

                if( apiResponse.List != null )
                {
                    foreach( var entry in apiResponse.List)
                    {
                        if( IsNoon ( entry.Dt ) )
                        {
                            WeatherData data = new WeatherData()
                            {
                                Clouds = entry.Clouds.All,
                                Date = DateTimeOffset.FromUnixTimeSeconds(entry.Dt).Date,
                                Description = entry.Weather[0].Description,
                                Pressure = entry.Main.Pressure,
                                Temp = entry.Main.Temp,
                                Wind = entry.Wind.Speed,
                                Type = MapWeatherType(entry)
                            };

                            weatherDataList.Add(data);
                        }
                    }
                }

            }

            //make sure that we have proper order
            weatherDataList = weatherDataList.OrderBy(x => x.Date).ToList();

            return weatherDataList;
        }

        /// <summary>
        /// Methos check if unix timestamp is noon
        /// </summary>
        /// <param name="Dt">Unix timestamp</param>
        /// <returns></returns>
        private bool IsNoon( int Dt)
        {
            var dt = DateTimeOffset.FromUnixTimeSeconds( Dt );

            if ( dt.Hour == 12 )
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Business logic for calculate weather type
        /// </summary>
        /// <param name="weatherData">Weather data from openweathermap </param>
        /// <returns>Weather type</returns>
        private WeatherTypes MapWeatherType( OList weatherData)
        {
            if (weatherData.Weather[0].Main.ToLower().Contains("rain"))
            {
                return WeatherTypes.Rainy;
            }

            if (weatherData.Weather[0].Main.ToLower().Contains("snow"))
            {
                return WeatherTypes.Snowy;
            }

            if (weatherData.Clouds.All > 70)
            {
                return WeatherTypes.Cloudy;
            }

            if (weatherData.Wind.Speed > 8)
            {
                return WeatherTypes.Windy;
            }

            return WeatherTypes.Sunny;
        }
    }
}
