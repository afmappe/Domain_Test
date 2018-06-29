using Cars.Library.Domain.Brands.Commands;
using Cars.Library.Domain.Brands.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cars.Web.Controllers
{
    [RoutePrefix("api/hola")]
    public class BrandController : ApiController
    {
        private readonly IMediator _Mediator;

        public BrandController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        [Route("")]
        public async Task<BrandModel> Create(CreateBrandCommand.Request request)
        {
            int result = await _Mediator.Send(request);
            request.Id = result;
            return request;
        }

        [Route("")]
        public async Task<IEnumerable<BrandModel>> Get()
        {
            BrandModel model = await _Mediator.Send(new GeBrandCommand.Request { Id = 147 });
            return new BrandModel[] { model };
        }

        [Route("{id:int}")]
        public async Task<BrandModel> Get(int id)
        {
            return await _Mediator.Send(new GeBrandCommand.Request { Id = id });
        }
    }
}