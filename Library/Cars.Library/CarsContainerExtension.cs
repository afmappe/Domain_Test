using Cars.Library.Extensions;
using Cars.Library.Infrastructure.Data;
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
            //Container
            //   .RegisterType<IDbContextFactory<CarsContext>, DbContextFactory<CarsContext>>(new ContainerControlledLifetimeManager());

            Container.RegisterType<CarsContext>(new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new DbContextFactory<CarsContext>().Create()));

            Container.RegisterType<UnitOfWorkFactory>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IUnitOfWork, CarUnitOfWork>();

            Container.RegisterMediator(new HierarchicalLifetimeManager())
             .RegisterGenericInterface(typeof(IAsyncRepository<>), () => new PerResolveLifetimeManager())
             .RegisterInterface(typeof(IQueryRepository), () => new PerResolveLifetimeManager());
        }
    }
}