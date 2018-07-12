using Cars.Library.Domain;
using Cars.Library.Extensions;
using Cars.Library.Infrastructure.Data.Context;
using Cars.Library.Infrastructure.Data.Interfaces;
using Unity;
using Unity.Extension;
using Unity.Injection;
using Unity.Lifetime;

namespace Cars.Library
{
    public class CarsContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<CarsContext>(new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new DbContextFactory<CarsContext>().Create()));

            Container.RegisterType<ICarUnitOfWorkFactory, CarUnitOfWorkFactory>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ICarUnitOfWork, CarUnitOfWork>(new TransientLifetimeManager());

            Container.RegisterMediator(new HierarchicalLifetimeManager())
             .RegisterGenericInterface(typeof(IAsyncRepository<>), () => new PerResolveLifetimeManager())
             .RegisterInterface(typeof(IQueryRepository), () => new PerResolveLifetimeManager());
        }
    }
}