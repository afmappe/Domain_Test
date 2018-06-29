using Cars.Web.App_Start;
using Cars.Web.Areas.HelpPage;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Unity;

namespace Cars.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //// Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/XmlDocument.xml")));

            DependecyInyection(config);
        }

        private static void DependecyInyection(HttpConfiguration config)
        {
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            UnityConfig.RegisterTypes(container);
            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}