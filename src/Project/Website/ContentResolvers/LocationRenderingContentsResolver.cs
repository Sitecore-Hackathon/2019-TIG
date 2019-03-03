using Sitecore.LayoutService.Configuration;
using Sitecore.Mvc.Presentation;
using System.Collections.Specialized;
using System.Web.Mvc;
using Website.Services;

namespace Website.ContentResolvers
{
    public class LocationRenderingContentsResolver : Sitecore.LayoutService.ItemRendering.ContentsResolvers.IRenderingContentsResolver
    {
        public bool IncludeServerUrlInMediaUrls { get; set; }
        public bool UseContextItem { get; set; }
        public string ItemSelectorQuery { get; set; }
        public NameValueCollection Parameters { get; set; }

        public object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            IWeatherService WeatherService = DependencyResolver.Current.GetService<IWeatherService>();

            return new
            {
                country = WeatherService.GetLocationCountry(),
                city = WeatherService.GetLocationCity(),
            };
        }
    }
}