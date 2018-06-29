using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Cars.Web
{
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// Implementación de <see cref="HttpApplication"/>
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}