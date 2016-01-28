using System.Net.Http.Formatting;
using System.Web.Http;

namespace SmartClinic.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Clear();

            var jsonFormatter = new JsonMediaTypeFormatter();
            config.Formatters.Add(jsonFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional}
                );
        }
    }
}