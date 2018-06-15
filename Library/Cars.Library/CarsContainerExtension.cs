using Cars.Library.Extensions;
using Cars.Library.Infrastructure.Data.Context;
using Cars.Library.Infrastructure.Data.Interfaces;
using System.Data.Entity.Infrastructure;
using Unity;
using Unity.Extension;
using Unity.Lifetime;

namespace Cars.Library
{
    public class CarsContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container
                .RegisterType<IDbContextFactory<CarsContext>, DbContextFactory<CarsContext>>(new ContainerControlledLifetimeManager())

                .RegisterMediator(new HierarchicalLifetimeManager())
                .RegisterGenericInterface(typeof(IAsyncRepository<>), () => new PerResolveLifetimeManager())
                .RegisterInterface(typeof(IQueryRepository), () => new PerResolveLifetimeManager());
        }
    }
}