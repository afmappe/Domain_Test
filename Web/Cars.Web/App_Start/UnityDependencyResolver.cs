using Cars.Library.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Exceptions;

namespace Cars.Web.App_Start
{
    /// <summary>
    ///
    /// </summary>
    public class UnityDependencyResolver : Disposable, IDependencyResolver
    {
        /// <summary>
        /// <see cref="IUnityContainer"/>
        /// </summary>
        protected readonly IUnityContainer _Container;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="container">Contenedor de dependencias</param>
        public UnityDependencyResolver(IUnityContainer container)
        {
            _Container = container ?? throw new ArgumentNullException("container");
        }

        /// <summary>
        /// Implementación de <see cref="IDependencyResolver.BeginScope"/>
        /// </summary>
        public IDependencyScope BeginScope()
        {
            IUnityContainer childContainer = _Container.CreateChildContainer();
            return new UnityDependencyResolver(childContainer);
        }

        /// <summary>
        /// Implementación de <see cref="IDependencyScope.GetService(Type)"/>
        /// </summary>
        public object GetService(Type serviceType)
        {
            try
            {
                return _Container.Resolve(serviceType);
            }
            catch (ResolutionFailedException ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Implementación de <see cref="IDependencyScope.GetServices(Type)"/>
        /// </summary>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _Container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException ex)
            {
                return new List<object>();
            }
        }

        /// <summary>
        /// Implementación de <see cref="Disposable.InternalDispose"/>
        /// </summary>
        protected override void InternalDispose()
        {
            _Container.Dispose();
        }
    }
}