using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System.Web.Http;

namespace Shop.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // enable Cross Origin
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
            //new DefaultContractResolver { IgnoreSerializableAttribute = true };

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
