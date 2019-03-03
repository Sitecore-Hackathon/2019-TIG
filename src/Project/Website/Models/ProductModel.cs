using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class ProductModel
    {
        [JsonIgnore]
        public static string NameFieldName = "{2EA64080-9CE8-5B09-927E-1ECD05B915E8}";
        [JsonIgnore]
        public static string CategoryFieldName = "{A4030B15-5C4B-533D-8AC6-1576C4EC8FF0}";
        [JsonIgnore]
        public static string WeatherTypeFieldName = "{38474350-B1D3-59F8-85D6-1C7D80BA495D}";
        [JsonIgnore]
        public static string ImageFieldName = "{0D1DBE03-B731-5E26-BEE9-0BBA59B45230}";
        [JsonIgnore]
        public static string DescriptionFieldName = "{C89524C2-A202-52A7-998D-94E1BE8C32E7}";
        [JsonIgnore]
        public static string PriceFieldName = "{D15AE8E1-3AFC-5F9E-A03E-89A1B9CCB236}";

        public string Name { get; set; }
        public string Category { get; set; }
        public string WeatherType { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}