using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.Services;

namespace Website.Controllers
{
    public class ProductController : Controller
    {

        private IWeatherService WeatherService;

        public ProductController()
        {
            WeatherService = DependencyResolver.Current.GetService<IWeatherService>();
        }


        /// <summary>
        /// Add to session products that have already been bought
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SetBuyProduct(string productId)
        {
            var productList = WeatherService.GetProductsFromSession();
            if (productList == null)
            {
                productList = new List<string>();
                productList.Add(productId);
                WeatherService.SetProductsFromSession(productList);
                var Response = JsonConvert.SerializeObject(new BaseApiResponse()
                {
                    Message = "ok",
                    Success = true,
                });
                return Content(Response, "application/json");
            }
            
            foreach(var product in productList)
            {
                if (product == productId)
                {
                    var ok = JsonConvert.SerializeObject(new BaseApiResponse()
                    {
                        Message = "exist",
                        Success = true,
                    });
                    return Content(ok, "application/json");
                }
            }

            productList.Add(productId);

            WeatherService.SetProductsFromSession(productList);

            var result = JsonConvert.SerializeObject(new BaseApiResponse()
            {
                Message = "ok",
                Success = true,
            });
            return Content(result, "application/json");
        }

    }
}