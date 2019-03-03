using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using System.Collections.Generic;
using WeatherProvider.Interface.Providers;
using Website.Services;

namespace Website.App_Start
{
    public class Dependencies : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IWeatherService, WeatherService>();
        }
    }
}