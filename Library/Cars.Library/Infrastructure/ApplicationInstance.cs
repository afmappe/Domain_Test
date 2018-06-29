using Unity;

namespace Cars.Library.Infrastructure
{
    public class ApplicationContext : ApplicationInstance
    {
        #region Singleton Pattern

        /// <summary>
        /// Objeto de bloqueo para creación de instancia
        /// </summary>
        private static readonly object sync = new object();

        /// <summary>
        /// Objeto para la creación de instancia
        /// </summary>
        private static volatile ApplicationContext instance;

        /// <summary>
        /// Referencia a la única instancia
        /// </summary>
        public static ApplicationContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {
                        if (instance == null)
                        {
                            instance = new ApplicationContext();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion
    }

    /// <summary>
    ///
    /// </summary>
    public class ApplicationInstance
    {
        /// <summary>
        /// Contenedor de resolución de dependencias
        /// </summary>
        public readonly IUnityContainer Container;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ApplicationInstance()
        {
            Container = new UnityContainer();
            Container.AddNewExtension<CarsContainerExtension>();
        }

        /// <summary>
        /// Resuelve una instancia registrada en el contenedor
        /// </summary>
        /// <typeparam name="T">Tipo de la instancia</typeparam>
        /// <param name="name">Nombre de la instancia</param>
        /// <returns></returns>
        public T Resolve<T>(string name = null)
        {
            return Container.Resolve<T>(name);
        }
    }
}