using Cars.Library.Domain.Brands.Commands;
using Cars.Library.Domain.Cars.Commands;
using Cars.Library.Infrastructure.Data;
using Cars.Library.Infrastructure.Data.Interfaces;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Cars.Test
{
    [TestClass]
    public class BrandTest : TestBase
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            IMediator mediator = Resolve<IMediator>();

            using (IUnitOfWork unitOfWork = Resolve<UnitOfWorkFactory>().Create())
            {
                int id = await mediator.Send(new CreateBrandCommand.Request { Name = string.Format("Marca{0}", Guid.NewGuid().ToString("n")) });

                await mediator.Send(new CreateCarCommand.Request { ModelId = id });

                unitOfWork.RejectChanges();
            }
        }
    }
}