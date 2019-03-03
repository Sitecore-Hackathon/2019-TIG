using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;

namespace Website.Infrastructure.Pipelines
{
    public class RegisterWebApiRoutes
    {
        public void Process(PipelineArgs args)
        {
            RouteTable.Routes.MapRoute("WeatherController", "tig/weather/{action}", new
            {
                controller = "Weather"
            });

            RouteTable.Routes.MapRoute("ProductController", "tig/product/{action}", new
            {
                controller = "Product"
            });
        }
    }
}