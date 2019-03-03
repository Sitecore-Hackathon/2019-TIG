using Newtonsoft.Json;
using Sitecore;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.LayoutService.Configuration;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using WeatherProvider.Interface.Data;
using Website.Controllers;
using Website.Helpers;
using Website.Models;
using Website.Services;

namespace Website.ContentResolvers
{
    public class ProductRenderingContentsResolver : Sitecore.LayoutService.ItemRendering.ContentsResolvers.IRenderingContentsResolver
    {
        public bool IncludeServerUrlInMediaUrls { get; set; }
        public bool UseContextItem { get; set; }
        public string ItemSelectorQuery { get; set; }
        public NameValueCollection Parameters { get; set; }

        /// <summary>
        /// Resolver modification product list show best choosed items for actual session
        /// define:
        /// /sitecore/system/Modules/Layout Service/Rendering Contents Resolvers/TigWeatherResolver
        /// usage in rendering 
        /// /sitecore/layout/Renderings/Project/traveler-last-hope/ProductsList
        /// field name 'Rendering Contents Resolver'
        /// 
        /// </summary>
        /// <param name="rendering"></param>
        /// <param name="renderingConfig"></param>
        /// <returns></returns>
        public object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var productFolder = rendering.Item.Database
                .GetItem("/sitecore/content/traveler-last-hope/Content/Data/PMD/Products");
            IWeatherService WeatherService = DependencyResolver.Current.GetService<IWeatherService>();

            var weatherSessionList = WeatherService.GetWeathersFromSession();
            if (weatherSessionList == null)
            {
                weatherSessionList = new List<WeatherData>();
            }

            List<Sitecore.Data.Items.Item> productList = new List<Sitecore.Data.Items.Item>();
            Set<string> addedProducts = new Set<string>();

            foreach (var weather in weatherSessionList) {
                foreach (Sitecore.Data.Items.Item product in productFolder.GetChildren())
                {
                    string[] strArray = product
                        .Fields[new ID(ProductModel.WeatherTypeFieldName)]
                        .Value
                        .Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string key in strArray)
                    {
                        if (weather.Type == MapperHelper.WeatherTypeSet[key] && !addedProducts.Contains(product.ID.ToString()))
                        {
                            addedProducts.Add(product.ID.ToString());
                            productList.Add(product);
                        }
                    }
                }
            }

            // removing items that have already been bought
            var productBoughtList = WeatherService.GetProductsFromSession();
            if (productBoughtList != null)
            {
                foreach(var product in productBoughtList)
                {
                    if (addedProducts.Contains(product))
                    {
                        foreach (var productSitecore in productList)
                        {
                            if (productSitecore.ID.ToString() == product)
                            {
                                productList.Remove(productSitecore);
                                break;
                            }
                        }
                    }
                }
            }
            List<ProductModel> resultList = new List<ProductModel>(); 

            foreach(var productSitecore in productList)
            {
                ImageField imageField = productSitecore.Fields[new ID(ProductModel.ImageFieldName)];
                string imageUrl = "";
                if (imageField?.MediaItem != null)
                {
                    var image = new MediaItem(imageField.MediaItem);
                    imageUrl = StringUtil.EnsurePrefix('/', MediaManager.GetMediaUrl(image));
                }

                resultList.Add(new ProductModel()
                {
                    Category = productSitecore.Fields[new ID(ProductModel.CategoryFieldName)].Value,
                    Description = productSitecore.Fields[new ID(ProductModel.DescriptionFieldName)].Value,
                    Image = imageUrl,
                    Name = productSitecore.Fields[new ID(ProductModel.NameFieldName)].Value,
                    Price = productSitecore.Fields[new ID(ProductModel.PriceFieldName)].Value,
                    WeatherType = productSitecore.Fields[new ID(ProductModel.WeatherTypeFieldName)].Value,
                });
            }

            return resultList;
        }
    }
}