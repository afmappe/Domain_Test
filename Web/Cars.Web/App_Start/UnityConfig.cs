using Cars.Library;
using Cars.Library.Infrastructure;
using Unity;

namespace Cars.Web.App_Start
{
    public static class UnityConfig
    {
        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return ApplicationContext.Instance.Container;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.AddNewExtension<CarsContainerExtension>();
        }
    }
}