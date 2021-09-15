using System.Web.Http;

namespace GismeteoService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{cityId}",
                defaults: new { cityId = RouteParameter.Optional }
            );            
        }
    }
}
