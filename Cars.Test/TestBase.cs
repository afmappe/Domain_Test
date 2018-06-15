using Cars.Library;
using Unity;

namespace Cars.Test
{
    public class ApplicationInstance
    {
        public readonly IUnityContainer Container;

        public ApplicationInstance()
        {
            Container = new UnityContainer();
            Container.AddNewExtension<CarsContainerExtension>();
        }
    }

    public class TestBase
    {
        #region Singleton Pattern

        /// <summary>
        /// Objeto de bloqueo para creación de instancia
        /// </summary>
        private static readonly object sync = new object();

        /// <summary>
        /// Objeto para la creación de instancia
        /// </summary>
        private static volatile ApplicationInstance instance;

        /// <summary>
        /// Referencia a la única instancia
        /// </summary>
        public static ApplicationInstance Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {
                        if (instance == null)
                        {
                            instance = new ApplicationInstance();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        public T Resolve<T>(string name = null)
        {
            return Instance.Container.Resolve<T>(name);
        }
    }
}