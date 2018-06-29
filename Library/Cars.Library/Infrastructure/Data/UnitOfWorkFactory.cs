using Cars.Library.Infrastructure.Data.Interfaces;
using Unity;

namespace Cars.Library.Infrastructure.Data
{
    public class UnitOfWorkFactory
    {
        private readonly IUnityContainer container;

        public UnitOfWorkFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public IUnitOfWork Create(string name = null)
        {
            return container.Resolve<IUnitOfWork>(name);
        }
    }
}