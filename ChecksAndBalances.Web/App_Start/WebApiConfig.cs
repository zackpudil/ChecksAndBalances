using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using ChecksAndBalances.Web.Formatters;
using WebApiContrib.IoC.Ninject;

namespace ChecksAndBalances.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("json", "application/json"));
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("xml", "application/xml"));

            var image = new ArticleImageFormatter();
            image.MediaTypeMappings.Add(new UriPathExtensionMapping("jpeg", "image/jpeg"));
            image.MediaTypeMappings.Add(new UriPathExtensionMapping("jpg", "image/jpg"));
            image.MediaTypeMappings.Add(new UriPathExtensionMapping("gif", "image/gif"));
            image.MediaTypeMappings.Add(new UriPathExtensionMapping("png", "image/png"));

            config.Formatters.Add(image);

            config.Routes.MapHttpRoute(
               name: "Api UriPathExtension",
               routeTemplate: "api/{controller}.{ext}/{id}",
               defaults: new { id = RouteParameter.Optional, ext = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "Api UriPathExtension ID",
              routeTemplate: "api/{controller}/{id}.{ext}",
              defaults: new { id = RouteParameter.Optional, ext = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
