using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ContosoUniversity
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //config.MapHttpAttributeRoutes();
            //// This next commented out line was causing the problem
            ////var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;

            //// This next line was the solution
            //var jsonFormatter = config.Formatters.JsonFormatter;
            //jsonFormatter.UseDataContractJsonSerializer = false; // defaults to false, but no harm done
            //jsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            //jsonFormatter.SerializerSettings.Formatting = Formatting.None;
            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //json.UseDataContractJsonSerializer = true;

            config.Routes.MapHttpRoute(
                name: "GetStudentDTO",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
        }
    }
}
