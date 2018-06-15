using Cars.Library.Domain.Brands.Commands;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Cars.Test
{
    [TestClass]
    public class BrandTest : TestBase
    {
        [TestMethod]
        public void TestMethod1()
        {
            IMediator mediator = Resolve<IMediator>();

            int a = Task.Run(() => mediator.Send(new CreateBrandCommand.Request { Name = "Hola Mundo" })).Result;
        }
    }
}