using Sitecore.LayoutService.Configuration;
using Sitecore.Mvc.Presentation;
using System.Collections.Specialized;
using System.Web.Mvc;
using Website.Services;
using System.Linq;
using Website.Models;
using Website.Helpers;
using Sitecore.Data;
using WeatherProvider.Interface.Data;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Sitecore;
using Sitecore.Data.Fields;
using System.Collections.Generic;

namespace Website.ContentResolvers
{
    public class WeatherRenderingContentsResolver : Sitecore.LayoutService.ItemRendering.ContentsResolvers.IRenderingContentsResolver
    {
        public bool IncludeServerUrlInMediaUrls { get; set; }
        public bool UseContextItem { get; set; }
        public string ItemSelectorQuery { get; set; }
        public NameValueCollection Parameters { get; set; }

        public object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            IWeatherService WeatherService = DependencyResolver.Current.GetService<IWeatherService>();
            List<WeatherDataModel> listdata = new List<WeatherDataModel>();
            var ret = WeatherService.GetWeathersFromSession();
            if ( ret != null )
            {
                listdata = ret.Select(d => new WeatherDataModel(d) { ImageUrl = GetWaterTypeImageUrl(d.Type) })
                .ToList();
            }
            return listdata;
        }

        private string GetWaterTypeImageUrl(WeatherTypes type)
        {
            var imageUrl = string.Empty;

            if (!MapperHelper.WeaterTypeToItemId.ContainsKey(type))
            {
                return imageUrl;
            }

            var weaterTypeItem = Sitecore.Context.Database.GetItem(new ID(MapperHelper.WeaterTypeToItemId[type]));

            ImageField imageField = weaterTypeItem.Fields["image"];
            if (imageField?.MediaItem != null)
            {
                var image = new MediaItem(imageField.MediaItem);
                imageUrl = StringUtil.EnsurePrefix('/', MediaManager.GetMediaUrl(image));
            }

            return imageUrl;
        }
    }
}