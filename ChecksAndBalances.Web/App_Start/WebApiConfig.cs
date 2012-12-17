using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using ChecksAndBalances.Web.Formatters;

namespace ChecksAndBalances.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("json", "application/json"));
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("xml", "application/xml")); 

            var jpeg = new ArticleImageJpegFormatter();
            jpeg.MediaTypeMappings.Add(new UriPathExtensionMapping("jpg", "image/jpg"));

            config.Formatters.Add(jpeg);

            config.Routes.MapHttpRoute(
                name: "ControllerWithExt",
                routeTemplate: "api/{controller}.{ext}");

            config.Routes.MapHttpRoute(
                name: "IdWithExt",
                routeTemplate: "api/{controller}/{id}.{ext}");

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ); 
        }
    }
}
