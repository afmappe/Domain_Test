using Cars.Library.Infrastructure.Data.Interfaces;
using Unity;

namespace Cars.Library.Domain
{
    /// <summary>
    /// Representa un UnitOfWork del dominio
    /// </summary>
    public interface ICarUnitOfWorkFactory : IUnitOfWorkFactory
    { }

    /// <summary>
    /// Fabrica de UnitOfWork del dominio
    /// </summary>
    public class CarUnitOfWorkFactory : ICarUnitOfWorkFactory
    {
        private readonly IUnityContainer _Container;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public CarUnitOfWorkFactory(IUnityContainer container)
        {
            _Container = container;
        }

        /// <summary>
        /// Implementación de <see cref="IUnitOfWork"/>
        /// </summary>
        /// <returns></returns>
        public IUnitOfWork Create()
        {
            return _Container.Resolve<ICarUnitOfWork>();
        }
    }
}