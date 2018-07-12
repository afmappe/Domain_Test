using Cars.Library.Domain.Cars.Commands;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Cars.Test
{
    [TestClass]
    public class CarTest : TestBase
    {
        public static CreateCarCommand.Request TestCarModelData
        {
            get
            {
                return new CreateCarCommand.Request()
                {
                    BrandName = "Ranault",
                    ModelName = "Sandero",
                    IsAvailable = true,
                    IsNew = false,
                    License = "IWS256",
                    Year = 2016
                };
            }
        }

        [TestMethod]
        public async Task TestMethod1()
        {
            IMediator mediator = Resolve<IMediator>();
            await mediator.Send(TestCarModelData);
        }
    }
}